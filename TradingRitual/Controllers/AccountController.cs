﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.DataAccess.Repository.Implementation;
using TradingRitual.DTO.RequestDTOs;
using TradingRitual.Entities.Models;

namespace TradingRitual.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IDataStore<Profile> _profileDataStore;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger, 
            IDataStore<Profile> profileDataStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _profileDataStore = profileDataStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var user = new ApplicationUser
                    {
                        FullName = model.FullName,
                        UserName = model.Email,
                        Email = model.Email
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    //var ownerId = _userManager.GetUserId(User);

                    if (result.Succeeded)
                    {


                        //check if role exists
                        var roleExists = await _roleManager.RoleExistsAsync("Owner");

                        IdentityResult roleResult;

                        //if roleExists add newly registered user to "Owner" role
                        //else create "Owner" role and add newly registered to the role
                        if (roleExists)
                        {
                            roleResult = await _userManager.AddToRoleAsync(user, "Owner");

                        }
                        else
                        {
                            await _roleManager.CreateAsync(new IdentityRole("Owner"));
                            roleResult = await _userManager.AddToRoleAsync(user, "Owner");
                        }

                        if (roleResult.Succeeded)
                        {
                            var userid = Guid.Parse(user.Id);


                            var profile = new Profile()
                            {
                                FullName = model.FullName,
                                Email = model.Email,
                                Password = model.Password,
                                ID = userid

                            };

                            //add new user to Owner table
                            var addOwner = _profileDataStore.Post(profile);



                            if (addOwner == null)
                            {

                                await _userManager.RemoveFromRoleAsync(user, "Owner");
                                await _userManager.DeleteAsync(user);

                            }


                            return RedirectToAction("index","home");
                        }
                        else
                        {
                            foreach (var item in roleResult.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }

                    }



                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }



                }
            }
            catch (Exception error)
            {
                // throw error;
                return View(error);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
            
                //var userRole = GetUserRole(user).Result;
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,
                                                                          model.RememberMe, false);
                if (user != null && result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Owner"))
                    {
                        return RedirectToAction("index", "home");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "ADMIN"))
                    {
                        return RedirectToAction("index", "admin");
                    }

                }

                ModelState.AddModelError(string.Empty, "Please check your credentials and try again");
            }

            return View(model);
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"{email} is currently in use");
            }


        }
    }
}

﻿let checkLists = [];

function renderTodo(todo) {
    localStorage.setItem('checkLists', JSON.stringify(checkLists));

    const list = document.querySelector('#js-todo-list');
    const item = document.querySelector(`[data-key='${todo.id}']`);

    if (todo.deleted) {
        item.remove();
        if (checkLists.length === 0) list.innerHTML = '';
        return
    }

    const isChecked = todo.checked ? 'done' : '';
    const node = document.createElement("li");
    node.setAttribute('class', `list-group-item`);
    node.setAttribute('data-key', todo.id);

    node.innerHTML = `
    <div class="todo-indicator bg-success"></div>
      
        <div class="widget-content p-0">
            <div class="widget-content-wrapper">
                <div class="widget-content-left mr-1">

                </div>
                <div class="widget-content-left flex2">
                        <div  class="widget-heading">${todo.text}</div>
                        <label for="${todo.id}" class="tick js-tick" hidden></label> 
                </div>
                  
   <div class="widget-content-right">

                </div>
                <div class="widget-content-right">
                       
                           <button type="button" class="js-delete-todo border-0 btn-transition btn btn-outline-danger ">

                        <i class="fa fa-trash-alt"></i>
                    </button>
                       
                </div>
            </div>
        </div>`;




    if (item) {
        list.replaceChild(node, item);
    } else {
        list.append(node);
    }
                 
}

function addTodo(text) {
    const todo = {
        text,
        checked: false,
        id: Date.now(),
    };

    checkLists.push(todo);
    renderTodo(todo);
}

function toggleDone(key) {
    const index = checkLists.findIndex(item => item.id === Number(key));
    checkLists[index].checked = !checkLists[index].checked;
    renderTodo(checkLists[index]);
  
}

function deleteTodo(key) {
    const index = checkLists.findIndex(item => item.id === Number(key));
    const todo = {
        deleted: true,
        ...checkLists[index]
    };
    checkLists = checkLists.filter(item => item.id !== Number(key));
    renderTodo(todo);
    alert("delete works")
}
const form = document.querySelector('.click-me');
form.addEventListener('click', event => {
    event.preventDefault();
    const input = document.querySelector('.checklist-input');

    const text = input.value.trim();
    if (text !== '') {
        addTodo(text);
        input.value = '';
        input.focus();
    }
});

const list = document.querySelector('.todo-list-wrapper');
list.addEventListener('click', event => {
  
    if (event.target.classList.contains('.js-tick')) {
        const itemKey = event.target.parentElement.dataset.key;
        toggleDone(itemKey);
    }


    if (event.target.classList.contains('.js-delete-todo')) {
        event.preventDefault();
        const itemKey = event.target.parentElement.parentElement;
        deleteTodo(itemKey);
        alert("delete works")
    }
});



document.addEventListener('DOMContentLoaded', () => {
    const ref = localStorage.getItem('checkLists');
    if (ref) {
        checkLists = JSON.parse(ref);
        checkLists.forEach(t => {
            renderTodo(t);
        });
    }
});


//Handle checklists for exit strategy

let exitCheckLists = [];

function renderTodo(checklist) {
    localStorage.setItem('exitCheckLists', JSON.stringify(exitCheckLists));

    const list = document.querySelector('#js-todo-list');
    const item = document.querySelector(`[data-key='${checklist.id}']`);

    if (checklist.deleted) {
        item.remove();
        if (exitCheckLists.length === 0) list.innerHTML = '';
        return
    }

    const isChecked = checklist.checked ? 'done' : '';
    const node = document.createElement("li");
    node.setAttribute('class', `list-group-item`);
    node.setAttribute('data-key', checklist.id);

    node.innerHTML = `
    <div class="todo-indicator bg-success"></div>
      
        <div class="widget-content p-0">
            <div class="widget-content-wrapper">
                <div class="widget-content-left mr-1">

                </div>
                <div class="widget-content-left flex2">
                        <div  class="widget-heading">${checklist.text}</div>
                        <label for="${checklist.id}" class="tick js-tick" hidden></label> 
                </div>
                  
   <div class="widget-content-right">

                </div>
                <div class="widget-content-right">
                       
                           <button type="button" class="js-delete-exitCheckLists border-0 btn-transition btn btn-outline-danger ">

                        <i class="fa fa-trash-alt"></i>
                    </button>
                       
                </div>
            </div>
        </div>`;




    if (item) {
        list.replaceChild(node, item);
    } else {
        list.append(node);
    }

}

function addTodo(text) {
    const checklist = {
        text,
        checked: false,
        id: Date.now(),
    };

    exitCheckLists.push(checklist);
    renderTodo(checklist);
}

function toggleDone(key) {
    const index = exitCheckLists.findIndex(item => item.id === Number(key));
    exitCheckLists[index].checked = !exitCheckLists[index].checked;
    renderTodo(exitCheckLists[index]);

}

function deleteTodo(key) {
    const index = exitCheckLists.findIndex(item => item.id === Number(key));
    const checklist = {
        deleted: true,
        ...exitCheckLists[index]
    };
    exitCheckLists = exitCheckLists.filter(item => item.id !== Number(key));
    renderTodo(checklist);
    alert("delete works")
}
const form = document.querySelector('.click-add');
form.addEventListener('click', event => {
    event.preventDefault();
    const input = document.querySelector('.exitstrategy-input');

    const text = input.value.trim();
    if (text !== '') {
        addTodo(text);
        input.value = '';
        input.focus();
    }
});

const list = document.querySelector('.todo-list-wrapper');
list.addEventListener('click', event => {

    if (event.target.classList.contains('.js-tick')) {
        const itemKey = event.target.parentElement.dataset.key;
        toggleDone(itemKey);
    }

    if (event.target.classList.contains('.js-delete-exitCheckLists')) {
        event.preventDefault();
        const itemKey = event.target.parentElement.parentElement;
        deleteTodo(itemKey);
        alert("delete works")
    }
});



document.addEventListener('DOMContentLoaded', () => {
    const ref = localStorage.getItem('exitCheckLists');
    if (ref) {
        exitCheckLists = JSON.parse(ref);
        exitCheckLists.forEach(t => {
            renderTodo(t);
        });
    }
});
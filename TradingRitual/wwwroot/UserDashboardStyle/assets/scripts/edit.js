
var exitCount = 0;
var pairCount = 0
        $(document).ready(function () {        
            exitStrategyList();

            pairsList();
        });


        function exitStrategyList() {
            $.ajax({
                url: '/Strategy/GetExitStrategy',
                type: 'GET',
                dataType: 'json',
                success: function (exitStrategies) {
                    exitStrategyListSuccess(exitStrategies);
                },
                error: function (request, message, error) {
                    handleException(request, message, error);
                }
            });
        }


        // Display all strategy returned from Web API call
        function exitStrategyListSuccess(exitStrategies) {
        // Iterate over the collection of data
        $.each(exitStrategies, function (index, exitStrategy) {
            // Add a row to the strategy table
            exitStrategyAddRow(exitStrategy);
        });
        }

        // Add strategy row to <table>
        function exitStrategyAddRow(exitStrategy) {
            // First check if a <tbody> tag exists, add one if not
            if ($("#exitStrategyTable tbody").length == 0) {
                $("#exitStrategyTable").append("<tbody></tbody>");
            }

            // Append row to <table>
                $("#exitStrategyTable tbody").append(
                   exitStrategyBuildTableRow(exitStrategy));
                }

        // Build a <tr> for a row of table data
function exitStrategyBuildTableRow(exitStrategy) {
   
         exitCount++;
            var ret = `<tr> +
                    <td>${exitCount}</td>
                        <td>${exitStrategy.name}</td>
                        <td>${exitStrategy.description}</td>
                        <td><a href="../Strategy/EditExitStrategy/${exitStrategy.exitStrategyId}" class="btn btn-outline-primary">Edit</a> <button class="btn btn-outline-danger">Delete</button></td>
                    </tr>`;
            return ret;
        }




//For pairs




function pairsList() {
    $.ajax({
        url: '/Pair/GetPairs',
        type: 'GET',
        dataType: 'json',
        success: function (pairs) {
            pairsListSuccess(pairs);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}


// Display all strategy returned from Web API call
function pairsListSuccess(pairs) {
    // Iterate over the collection of data
    $.each(pairs, function (index, pair) {
        // Add a row to the strategy table
        pairAddRow(pair);
    });
}

// Add strategy row to <table>
function pairAddRow(pair) {
    // First check if a <tbody> tag exists, add one if not
    if ($("#pairTable tbody").length == 0) {
        $("#pairTable").append("<tbody></tbody>");
    }

    // Append row to <table>
    $("#pairTable tbody").append(
        pairBuildTableRow(pair));
}

// Build a <tr> for a row of table data
function pairBuildTableRow(pair) {
 
    pairCount++;
    var ret = `<tr> +
                    <td>${pairCount}</td>
                        <td>${pair.currencies}</td>
                        //<td><a href="../Pair/EditPairs/${pair.pairId}" class="btn btn-outline-primary">Edit</a> <button class="btn btn-outline-danger">Delete</button></td>
                    </tr>`;
    return ret;
}




function getInput(php_file) {
    let value = prompt("Skriv in patientens personnummer i format (ååååmmdd-xxxx): ");
    query_search(php_file, value);
}

function query_search(php_file, value) {
    $.ajax({url: "/scripts/queries/" + php_file + "?key=" + value, type: "get", success: function(result) {
        $("#sql-writer").html(result);
    }
    });
}

function query(php_file) {
    $.ajax({url: "/scripts/queries/" + php_file, success: function(result) {
        $("#sql-writer").html(result);
    }
    });
}
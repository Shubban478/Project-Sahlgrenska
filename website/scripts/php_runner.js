function getInput(php_file) {
    let id = prompt("Skriv in patientens personnummer i format (ååååmmdd-xxxx): ");

    let re = /[0-9]{8}-[0-9]{4}/;
    if (!re.test(id)) {
        alert("Personnumret är inte giltigt!");
        return;
    }
    query_search(php_file, id);
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
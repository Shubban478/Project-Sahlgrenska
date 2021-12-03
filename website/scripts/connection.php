<?php
    $servername = "bjjyx4krtcspjgah0tay-mysql.services.clever-cloud.com";
    $username = "ulhpxhgnf5tkywq2";
    $password = "CE2AriOp5v9YqliNasMM";
    $dbname = "bjjyx4krtcspjgah0tay";
    $port = "3306";

    // Create connection
    $conn = new mysqli($servername, $username, $password, $dbname, $port);

    // Check connection
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
    echo "Successfully connected to the database.<br><br>";
?>

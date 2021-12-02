<?php
function query() {
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

    // Query
    $sql = "SELECT doctor_name FROM doctors";
    $result = $conn->query($sql);

    echo "Running command: $sql<br>Output:<br>";
    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            foreach ($row as $r) {
                echo "$r";
            }
        }
    } else {
        echo "0 results";
    }
    $conn->close();
}
query();
?>
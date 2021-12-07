<?php
function query() {
    include "../connection.php";

    // Query
    $sql = "SELECT * FROM patients";
    $result = $conn->query($sql);

    echo "Running command: $sql<br>Output:<br>";
    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            foreach ($row as $r) {
                echo "$r<br>";
            }
        }
    } else {
        echo "0 results";
    }
    $conn->close();
}
query();
?>

<?php
function sqlQuery() {
    include "scripts/connection.php";

    $value = $_GET["patientid"];
    echo "Value: $value<br>";

    // Query
    $sql = "SELECT p.id, name, time, reason FROM patients as p LEFT JOIN patients_has_appointments as pa 
    ON p.id=pa.patients_id LEFT JOIN appointments as a ON pa.appointments_id=a.id WHERE p.id = '$value'";
    $result = $conn->query($sql);

    echo "Running command: $sql<br>Output:<br>";
    if ($result->num_rows > 0) {
        // output data based on info
        while ($row = $result->fetch_array(MYSQLI_NUM)) {
            for ($i=0; $i < count($row); $i+=4) {
                echo '<div class="sql-info">';
                echo "Ärendet gäller: ".$row[($i+1)]."<br>";
                echo "Tid och datum: ".$row[($i+2)]."<br>";
                echo "Anledning till besöket: ".$row[($i+3)]."<br>";
                echo "</div>";
            }
            //foreach ($row as $r) {
              //  echo "$r<br>";
            //}
        }
    } else {
        echo "0 results";
    }
    $conn->close();
}
sqlQuery();
?>

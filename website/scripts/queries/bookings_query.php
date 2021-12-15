<?php
function sqlQuery($patientid) {
    // Inclusion of db_reader.php is necessary
    
    // Query
    $sql = "SELECT p.id, name, time, reason FROM patients as p LEFT JOIN patients_has_appointments as pa 
    ON p.id=pa.patients_id LEFT JOIN appointments as a ON pa.appointments_id=a.id WHERE p.id = '$patientid'";

    $db = new db_reader();
    $result = $db->fetch_array($sql);

    // Check to see if no results have been returned
    if (is_string($result)) {
        if (!strcmp($result, "0 Results")) {
            echo "Error, no results found!";
            exit;
        }
    }
    // Output data in seperate divs
    echo "<h1>Bokningar för ".$result[0][1]."</h1>";

    for ($i=0; $i < count($result); $i++) {
        $row = $result[$i];
        echo '<div class="sql-info">';
        if ($row[2] == "" || is_null($row[2])) {
            echo "<h3>Inget ärende hittat för ".$row[1]."</h3></div>";
        } else {
            echo "<h3>Tid och datum: ".$row[2]."</h3>";
            echo "Ärendet gäller: ".$row[1]."<br>";
            echo "Anledning till besöket: ".$row[3]."<br>";
            echo "</div>";
        }
    }
}
sqlQuery($value);
?>

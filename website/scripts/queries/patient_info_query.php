<?php
function patient_info() {
    include "../db_reader.php";

    $key = $_GET["key"];

    // Query
    $sql = "SELECT * FROM patients_all WHERE id = '$key'";

    $db = new db_reader();
    $result = $db->fetch_array($sql);

    // Check to see if no results have been returned
    if (is_string($result)) {
        if (!strcmp($result, "0 Results")) {
            echo "Error, no results found!";
            exit;
        }
    }
    // output data based on info
    $row = $result[0];
    echo '<div class="sql-info">';
    echo "<h3>Namn: $row[1]</h3>";
    echo "Personnummer: $row[0]<br>";
    echo "Address: $row[2]<br>";
    echo "Kön: $row[3]<br>";
    echo "Inläggningsdatum: $row[4]<br><br>";
    echo "Diagnos: $row[8]<br>";
    echo "Kommentar: $row[9]<br><br>";
    echo "Journal: $row[6]";
    echo "</div>";

    // Get bookings
    $value = $row[0];
    include "bookings_query.php";
}
patient_info();
?>

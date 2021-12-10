<?php
function patient_info() {
    include "../db_reader.php";

    $key = $_GET["key"];

    // Query
    $sql = "SELECT * FROM patients WHERE id = '$key'";

    $db = new db_reader();
    $result = $db->fetch_array($sql);
    // output data based on info
    $row = $result[0];
    echo '<div class="sql-info">';
    echo "<h3>Namn: $row[1]</h3>";
    echo "Id: $row[0]<br>";
    echo "Address: $row[2]<br>";
    echo "Kön: $row[3]<br>";
    echo "Inläggningsdatum: $row[4]<br>";
    echo "</div>";

    // Get bookings
    $value = $row[0];
    include "bookings_query.php";
}
patient_info();
?>

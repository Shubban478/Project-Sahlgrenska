<?php
function criticalQuery() {
    // Query
    $sql = "SELECT * FROM patients WHERE history LIKE '%akut%'";

    $db = new db_reader();
    $result = $db->fetch_array($sql);

    // Check to see if no results have been returned
    if (is_string($result)) {
        if (!strcmp($result, "0 Results")) {
            echo "Error, no results found! (No patients in critical condition?)";
        }
    } else {
        echo "<h2>Varning! En eller flera patienter är i kritiskt tillstånd.</h2>";
        // Output data in seperate divs
        for ($i=0; $i < count($result); $i++) {
            $row = $result[$i];
            echo '<div class="sql-info" style="border:5px solid red">';
            echo "<h3 style='color:red'>CRITICAL CONDITION - ".$row[1]."</h3>";
            echo "Personnummer: ".$row[0]."<br>";
            echo "Address: ".$row[2]."<br>";
            echo "Kön: ".$row[3]."<br>";
            echo "Inläggningsdatum: ".$row[4]."<br>";
            echo "<br>Beskrivning: ".$row[6]."<br>";
            echo "</div>";
        }
    }
}
criticalQuery();
?>
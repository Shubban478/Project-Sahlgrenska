<?php
function sqlQuery() {
    include "../db_reader.php";
    
    // Check log-in credentials for query
    session_start();
    $userid = $_SESSION["id"];
    // Query
    $sql = "SELECT * from appointments_overview WHERE doktor=$userid";

    $db = new db_reader();
    $result = $db->fetch_array($sql);
    // Output data in seperate divs
    echo "<h1>Bokningar för ".$result[0][2]."</h1>";

    for ($i=0; $i < count($result); $i++) {
        $row = $result[$i];
        echo '<div class="sql-info">';
        if ($row[2] == "" || is_null($row[2])) {
            echo "<h3>Inget ärende hittat för ".$row[1]."</h3></div>";
        } else {
            echo "<h3>Tid och datum: ".$row[6]."</h3>";
            echo "Rum: ".$row[5]."<br>";
            echo "Patientens namn: ".$row[4]."<br>";
            echo "Patientens personnummer: ".$row[3]."<br>";
            echo "Anledning till besöket: ".$row[7]."<br><br>";
            echo "Utrustning: ".$row[8]."<br>";
            echo "Mediciner: ".$row[9]."<br>";
            echo "</div>";
        }
    }
}
sqlQuery($value);
?>

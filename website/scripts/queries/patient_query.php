<?php
function sqlQuery() {
    include "../db_reader.php";

    // Query
    $sql = "SELECT * FROM patients";

    $db = new db_reader();
    $result = $db->fetch_array($sql);
    // Output data in seperate divs
    for ($i=0; $i < count($result); $i++) {
        $row = $result[$i];
        echo '<div class="sql-info">';
        echo "<h3>".$row[1]."</h3>";
        echo "Personnummer: ".$row[0]."<br>";
        echo "Address: ".$row[2]."<br>";
        echo "Kön: ".$row[3]."<br>";
        echo "Inläggningsdatum: ".$row[4]."<br>";
        echo "</div>";
    }
}
sqlQuery();
?>

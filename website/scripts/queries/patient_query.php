<?php
function sqlQuery() {
    include "../db_reader.php";

    // Query
    $sql = "SELECT * FROM patients";

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
    for ($i=0; $i < count($result); $i++) {
        $row = $result[$i];
        if ($row[0] == "" || is_null($row[0])) {
            continue;
        }
        $color = "";
        $critical = ">";
        if ($row[7] == "Yes") {
            $color = "style='border:5px solid red'";
            $critical = "style='color:red'>CRITICAL CONDITION - ";
        }
        echo "<div class='sql-info '" . $color . ">";
        echo "<h3 ".$critical.$row[1]."</h3>";
        echo "Personnummer: ".$row[0]."<br>";
        echo "Address: ".$row[2]."<br>";
        echo "Kön: ".$row[3]."<br>";
        echo "Inläggningsdatum: ".$row[4]."<br>";
        echo "</div>";
    }
}
sqlQuery();
?>

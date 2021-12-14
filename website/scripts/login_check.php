<?php
if (isset($_POST)) {
    include "db_reader.php";

    $username = $_POST["username"];
    $password = $_POST["password"];
    
    $sql = "SELECT name, password, id FROM doctors WHERE name = '$username'";

    $db = new db_reader();
    $result = $db->fetch_array($sql);

    if ($password == $result[0][1]) {
        echo "<p style='color:green;'>Succesfully logged in, waiting on redirect.</p>";
        session_start();
        $_SESSION["username"] = $username;
        $_SESSION["id"] = $result[0][2];
        header("Location: /employee.php");
    } else {
        echo "Wrong password!";
    }
}
?>
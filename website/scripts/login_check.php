<?php
if (isset($_POST)) {
    include "connection.php";

    $username = $_POST["username"];
    $password = $_POST["password"];
    
    $sql = "SELECT name, password FROM doctors WHERE name = '$username'";
    #echo "$sql<br>";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        $row = $result->fetch_array(MYSQLI_ASSOC);
        // Compare passwords
        if ($password == $row["password"]) {
            echo "<p style='color:green;'>Succesfully logged in, waiting on redirect.</p>";
            session_start();
            $_SESSION["username"] = $username;
            header("Location: /employee.php");
        } else {
            echo "Wrong password!";
        }
    } else {
        echo "<p style='color:red;'>No user such as that!</p>";
    }
    $conn->close();
}
?>
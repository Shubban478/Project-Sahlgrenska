<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    include "connection.php";

    $username = $_POST["username"];
    $password = $_POST["password"];
    
    $sql = "SELECT name, password FROM doctors WHERE name = '$username'";
    echo "$sql<br>";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        $row = $result->fetch_array(MYSQLI_ASSOC);
        // Compare passwords
        if ($password == $row["password"]) {
            echo "Succesfully logged in.";
            session_start();
            $_SESSION["username"] = $username;
            header("Location: /employee.html");
        } else {
            echo "Wrong password!";
        }
    } else {
        echo "No user such as that!";
    }
    $conn->close();
}
?>

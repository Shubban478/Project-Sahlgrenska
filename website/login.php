<?php
session_start();
if (isset($_SESSION["username"])) {
    header("Location: /employee.php");
    exit;
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/styles.css">
    <title>Project-Sahlgrenska - Logga in</title>
</head>

<body>
    <div class="header">
        <h1 id="title">Projekt-Sahlgrenska</h1>
    </div>
    <div id="login-box">
        <h1>Login</h1>
        <form action="/scripts/login_check.php" method="post">
            <label for="username">Username: </label>
            <input type="text" name="username" id="username" required><br><br>
            <label for="password">Password: </label>
            <input type="password" name="password" id="password" required><br><br>
            <input type="submit" name="submit" id="submit">
            <?php
            $error = $_GET["error"];
            if (!strcmp($error, "true")) {
                echo "<div id='login-error'>";
                echo "<p style='color:darkred'>Username or password is wrong.</p></div>";
            }
            ?>
        </form>
        <a href="index.html">Tillbaka</a>
    </div>
</body>

</html>

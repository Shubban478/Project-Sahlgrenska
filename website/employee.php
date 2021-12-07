<?php
session_start();
if (!isset($_SESSION["username"])) {
    header("Location: /login.php");
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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <title>Projekt-Sahlgrenska - Inloggad</title>
</head>

<body>
    <div class="header">
        <h1 id="title">Projekt-Sahlgrenska</h1>
        <a id="logout-button" href="/scripts/logout.php">Logga ut</a>
        <nav class="flexbox" id="navbar">
            <a href="/index.html">Hem</a>
            <a href="">Bokningar</a>
            <a href="/index.html#about-us">Om oss</a>
            <a class="active" href="">Inloggad</a>
        </nav>
    </div>
    <main>
        <?php
        $username = $_SESSION["username"];
        $t = date("D d F", time());
        echo "<h1>Välkommen $username, idag är det $t</h1>";
        ?>
        <div class="button-container">
            <button onclick="query('patient_query.php')">Visa Patientlista</button>
            <button onclick="getInput('patient_info_query.php')">Sök patientinfo</button>
        </div>
        <div id="sql-writer"></div>
        <div id="temp"></div>
    </main>
    <footer>
        <div class="bottom-strip">
            <p>End of site.</p>
        </div>
    </footer>
</body>
<script src="/scripts/php_runner.js"></script>

</html>

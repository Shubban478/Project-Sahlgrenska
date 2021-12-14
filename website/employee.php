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
        <nav class="flexbox" id="navbar">
            <a href="/index.html">Hem</a>
            <a href="/index.html#about-us">Om oss</a>
            <a class="active" id="logout-button" href="/scripts/logout.php">Logga ut</a>
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
            <button onclick="query('doctor_bookings_query.php')">Visa dina bokningar</button>
        </div>
        <div id="sql-writer">
            <?php
            include "scripts/db_reader.php";
            include "scripts/queries/critical_query.php";
            ?>
        </div>
        <div id="temp"></div>
    </main>
    <footer>
        <div id="about-us">
            <h1><span>Projekt-Sahlgrenska</span> - ditt liv i våra händer</h1>
            <p>Här kan du läsa om din vård och göra bokningar direkt från webbsidan.</p>
        </div>
        <div class="bottom-strip">
            <p>End of site.</p>
        </div>
    </footer>
</body>
<script src="/scripts/php_runner.js"></script>

</html>

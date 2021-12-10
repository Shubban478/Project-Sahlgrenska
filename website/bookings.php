<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/styles.css">
    <title>Projekt-Sahlgrenska</title>
</head>

<body>
    <div class="header">
        <h1 id="title">Projekt-Sahlgrenska</h1>
        <nav class="flexbox" id="navbar">
            <a href="/index.html">Hem</a>
            <a class="active" href="">Bokningar</a>
            <a href="/index.html#about-us">Om oss</a>
            <a href="/login.php">Till intranätet</a>
        </nav>
    </div>
    <main>
        <?php
        //ini_set('display_errors', 1); error_reporting(-1);
        $value = $_GET["patientid"];
        include "scripts/db_reader.php";
        include "scripts/queries/bookings_query.php";
        ?>
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

</html>

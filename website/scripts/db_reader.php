<?php
// ini_set('display_errors', 1); error_reporting(-1);

class db_reader {

    protected $conn;

    public function __construct() {
        $servername = "bt0mlsay6vs1xbceqzzn-mysql.services.clever-cloud.com";
        $username = "ulhpxhgnf5tkywq2";
        $password = "CE2AriOp5v9YqliNasMM";
        $dbname = "bt0mlsay6vs1xbceqzzn";
        $port = "21191";

        $this->conn = new mysqli($servername, $username, $password, $dbname, $port);
        // Check connection
        if ($this->conn->connect_error) {
            die("Connection failed: " . $this->$conn->connect_error);
        }
        // echo "Successfully connected to the database.<br>";
    }

    public function query($sql) {
        $result = $this->conn->query($sql);
        return $result;
    }

    public function fetch_array($sql) {
        $query = $this->conn->query($sql);
        // echo "Running command: $sql<br>Output:<br>";
        if ($query->num_rows > 0) {
            $result = array();
            $i = 0;
            while ($row = $query->fetch_array(MYSQLI_NUM)) {
                $result[$i] = $row;
                $i++;
            }
            return $result;
        } else {
            return "0 Results";
        }
        $this->conn->close();
    }
}
?>
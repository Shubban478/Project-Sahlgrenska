-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: bjjyx4krtcspjgah0tay-mysql.services.clever-cloud.com    Database: bjjyx4krtcspjgah0tay
-- ------------------------------------------------------
-- Server version	8.0.22-13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ 'a05a675a-1414-11e9-9c82-cecd01b08c7e:1-491550428,
a38a16d0-767a-11eb-abe2-cecd029e558e:1-100181646';

--
-- Table structure for table `diagnosis`
--

DROP TABLE IF EXISTS `diagnosis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diagnosis` (
  `Name` varchar(255) NOT NULL,
  `Comments` varchar(255) DEFAULT NULL,
  `Symtoms` varchar(255) DEFAULT NULL,
  `Treatment` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diagnosis`
--

LOCK TABLES `diagnosis` WRITE;
/*!40000 ALTER TABLE `diagnosis` DISABLE KEYS */;
INSERT INTO `diagnosis` VALUES ('Halsfluss','Var uppmärksam på att halsbölder kan uppstå som följdsjukdom','Halsont vid sväljningar, feber, svullna lymfkörtlar (känns som ömma kulor under hunden).','Operation för borttagning utav halsmandlarna, antibiotika'),('Hjärtmuskelinflammation','Går över av sig själv. Kan kräva inläggning för obeservation beroende på svårighetsgrad.','Trött och andfådd, oregelbundna hjärtslag och hjärtklappning, feber och värk, tryck över bröstet, högre vilopuls','Smärtstillande läkemedel vid smärtor'),('Njursvikt','Behandling beror på om svikten är akut eller kronisk. Se behandling för mer information.','Blod i urinen, urinet skummar, trötthet, klåda, sämre aptit, illamående och kräkningar.','Vid akut njursvikt: vätska via dropp, kateter vid svårigheter att urinera. Inläggning till stabilisering. Kronisk Njursvikt: läkemedel för att sänka blodtrycket. Kan också ges tabletter mot illamående.'),('Överdriven svettning','Patienten kan uppleva problem med att ta andra människor i handen eller hantera papper och annat i skolan eller på arbetet.','Hudskador eller infektioner','Injektioner med botulinumtoxin'),('Schizofreni','Om patient får vård på sjukhus kan det ske frivilligt, eller genom användades utav \'LPT\' (Lagen om Psykiatrisk Tvångsvård) vid svåra symtom','Vanföreställningar, hallucinationer, tankestörningar','Neuroleptika, stödsamtal, utbildning om sjukdomen');
/*!40000 ALTER TABLE `diagnosis` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-03 16:37:24

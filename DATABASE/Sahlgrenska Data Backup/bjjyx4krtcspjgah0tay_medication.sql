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
a38a16d0-767a-11eb-abe2-cecd029e558e:1-99954572';

--
-- Table structure for table `medication`
--

DROP TABLE IF EXISTS `medication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medication` (
  `Name` varchar(255) NOT NULL,
  `Sideeffects` varchar(455) DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medication`
--

LOCK TABLES `medication` WRITE;
/*!40000 ALTER TABLE `medication` DISABLE KEYS */;
INSERT INTO `medication` VALUES ('Alluzience 200 Speywood-enheter/ml','Kraftig muskelsvaghet, svårigheter att svälja, hosta och kvävningsanfall vid sväljning (om mat eller vätska kommer in i luftvägarna när du försöker svälja kan du få problem i luftvägarna som t.ex. infektioner i lungorna)',327),('Inderal 40 mg','Långsam puls, kalla fingrar och tår, försämring av redan dålig blodcirkulation, trötthet eller muskelsvaghet, sömnstörningar, mardrömmar, andfåddhet. Domning, frusenhet och blekhet om fingrar och tår, när de utsätts för kyla och fukt (Raynauds fenomen)',1428),('Kåvepenin 500 mg','Magbesvär, främst illamående eller lös avföring samt hudutslag',2375),('Olanzapin 5 mg','Viktuppgång, sömnighet; och ökade nivåer av prolaktin i blodet. I början av behandlingen kan vissa personer känna sig yra eller svimma (med långsam hjärtfrekvens), särskilt när de reser sig från liggande eller sittande ställning.',2147),('OxyNorm 10 mg','Nedsatt aptit, ångest, förvirring, depression, sömnlöshet, nervositet, onormal tankeverksamhet, darrningar, försjunken i dvala (letargi), försämrad andning, luftrörskramp, buksmärtor, diarré, muntorrhet, matsmältningsbesvär, utslag, svettning, svaghetskänsla.',3204);
/*!40000 ALTER TABLE `medication` ENABLE KEYS */;
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

-- Dump completed on 2021-12-02 20:09:15

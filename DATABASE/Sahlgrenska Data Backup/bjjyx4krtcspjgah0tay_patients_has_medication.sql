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
a38a16d0-767a-11eb-abe2-cecd029e558e:1-100181643';

--
-- Table structure for table `patients_has_medication`
--

DROP TABLE IF EXISTS `patients_has_medication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients_has_medication` (
  `patients_ID` varchar(13) NOT NULL,
  `medication_Name` varchar(255) NOT NULL,
  PRIMARY KEY (`patients_ID`,`medication_Name`),
  KEY `fk_patients_has_medication_medication1_idx` (`medication_Name`),
  KEY `fk_patients_has_medication_patients1_idx` (`patients_ID`),
  CONSTRAINT `fk_patients_has_medication_medication1` FOREIGN KEY (`medication_Name`) REFERENCES `medication` (`Name`) ON UPDATE CASCADE,
  CONSTRAINT `fk_patients_has_medication_patients1` FOREIGN KEY (`patients_ID`) REFERENCES `patients` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients_has_medication`
--

LOCK TABLES `patients_has_medication` WRITE;
/*!40000 ALTER TABLE `patients_has_medication` DISABLE KEYS */;
INSERT INTO `patients_has_medication` VALUES ('19480216-0889','Olanzapin 5 mg'),('19530310-3518','Kåvepenin 500 mg'),('19550810-2489','Kåvepenin 500 mg'),('19691205-1668','Olanzapin 5 mg'),('19791012-3095','Kåvepenin 500 mg'),('19830504-3047','Inderal 40 mg'),('19910807-2795','OxyNorm 10 mg'),('19980318-2964','Olanzapin 5 mg'),('19981007-8296','Kåvepenin 500 mg'),('20000704-3284','Alluzience 200 Speywood-enheter/ml');
/*!40000 ALTER TABLE `patients_has_medication` ENABLE KEYS */;
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

-- Dump completed on 2021-12-03 16:37:21

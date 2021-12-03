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
a38a16d0-767a-11eb-abe2-cecd029e558e:1-99954568';

--
-- Table structure for table `doctors_has_patients`
--

DROP TABLE IF EXISTS `doctors_has_patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctors_has_patients` (
  `doctors_ID` int NOT NULL,
  `patients_ID` varchar(13) NOT NULL,
  PRIMARY KEY (`doctors_ID`,`patients_ID`),
  KEY `fk_doctors_has_patients_doctors1_idx` (`doctors_ID`),
  KEY `fk_doctors_has_patients_patients1_idx` (`patients_ID`),
  CONSTRAINT `fk_doctors_has_patients_doctors1` FOREIGN KEY (`doctors_ID`) REFERENCES `doctors` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `fk_doctors_has_patients_patients1` FOREIGN KEY (`patients_ID`) REFERENCES `patients` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctors_has_patients`
--

LOCK TABLES `doctors_has_patients` WRITE;
/*!40000 ALTER TABLE `doctors_has_patients` DISABLE KEYS */;
INSERT INTO `doctors_has_patients` VALUES (1,'19480216-0889'),(1,'19691205-1668'),(1,'19980318-2964'),(2,'19910807-2795'),(3,'19830504-3047'),(3,'20000704-3284'),(4,'19981007-8296'),(5,'19530310-3518'),(5,'19550810-2489'),(6,'19471013-6666'),(6,'19791012-3095'),(6,'19931013-8350');
/*!40000 ALTER TABLE `doctors_has_patients` ENABLE KEYS */;
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

-- Dump completed on 2021-12-02 20:09:12

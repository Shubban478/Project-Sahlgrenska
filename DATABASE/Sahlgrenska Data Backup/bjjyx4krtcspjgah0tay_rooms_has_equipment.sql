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
-- Table structure for table `rooms_has_equipment`
--

DROP TABLE IF EXISTS `rooms_has_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms_has_equipment` (
  `rooms_ID` int NOT NULL,
  `equipment_Name` varchar(225) NOT NULL,
  PRIMARY KEY (`rooms_ID`,`equipment_Name`),
  KEY `fk_rooms_has_equipment_equipment1_idx` (`equipment_Name`),
  KEY `fk_rooms_has_equipment_rooms1_idx` (`rooms_ID`),
  CONSTRAINT `fk_rooms_has_equipment_equipment1` FOREIGN KEY (`equipment_Name`) REFERENCES `equipment` (`Name`) ON UPDATE CASCADE,
  CONSTRAINT `fk_rooms_has_equipment_rooms1` FOREIGN KEY (`rooms_ID`) REFERENCES `rooms` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms_has_equipment`
--

LOCK TABLES `rooms_has_equipment` WRITE;
/*!40000 ALTER TABLE `rooms_has_equipment` DISABLE KEYS */;
INSERT INTO `rooms_has_equipment` VALUES (1,'Bladder Scanner BVT01'),(2,'MacroView Prestige LED-Otoskop-Set'),(3,'MacroView Prestige LED-Otoskop-Set'),(4,'MacroView Prestige LED-Otoskop-Set'),(5,'MacroView Prestige LED-Otoskop-Set'),(6,'iMAC1800A EKG');
/*!40000 ALTER TABLE `rooms_has_equipment` ENABLE KEYS */;
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

-- Dump completed on 2021-12-03 16:37:26

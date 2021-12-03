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
a38a16d0-767a-11eb-abe2-cecd029e558e:1-99954588';

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `ID` varchar(13) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Gender` varchar(1) DEFAULT NULL,
  `Admitted` datetime DEFAULT NULL,
  `Senthome` datetime DEFAULT NULL,
  `Reason` varchar(2555) DEFAULT NULL,
  `History` varchar(2555) DEFAULT NULL,
  `Appointment` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES ('19471013-6666','Thomas Stenström','Slåmighårtiansiktet 145, TENSTA Stockholm','M','2021-12-17 00:00:00',NULL,'Fick en gitarr i ögonbrynet CRITICAL',NULL,'2022-01-08 11:20:00'),('19480216-0889','Ofelia Månsson','Lemesjö 13, 570 91, KRISTDALA','F','2021-12-01 00:00:00',NULL,'Sprang in på ICA Kvantum utan kläder. Inkommer med polis','Närstående upplever förändrat habitaltillstånd och kör in till oss','2022-01-19 10:30:00'),('19530310-3518','Mats Sjögren','Hökgatan 99, 823 26, KILAFORS','M','2021-12-01 00:00:00',NULL,'Hög feber under några dagar och säger själv att det känns som rakblad i halsen',NULL,'2022-02-27 14:50:00'),('19550810-2489','Sanna Persson','Gulleråsen Västabäcksgatu 58, 372 10, JOHANNESHUS','F','2021-12-01 00:00:00',NULL,'Kan inte äta på grund av halsont och hög feber',NULL,'2022-01-03 17:00:00'),('19691205-1668','Isolde Söderberg','Östanlid 52, 432 29, VARBERG','F','2021-12-01 00:00:00',NULL,'Närstående upplever försämring i hennes schizofreni','Påstår sig sett Gud i spegeln, uppvisar schizofrena tecken','2022-01-04 12:00:00'),('19791012-3095','Alexander Sandström','Ovansjövägen 93, 570 01, RÖRVIK','M','2021-12-01 00:00:00',NULL,'Smärtor i lymfkörtlar',NULL,'2022-01-11 08:10:00'),('19830504-3047','Hanan Nordin','Hålebäcksvägen 36, 791 95, FALUN','F','2021-12-01 00:00:00',NULL,'Joggade med feber och upplever efter detta smärtor i bröstet critical','Bruten arm, inkommer med ambulans','2022-01-14 09:30:00'),('19910807-2795','Zakaria Olofsson','Läktargatan 19, 260 36, ÖDÅKRA-VÅLA','M','2021-12-01 00:00:00',NULL,'Illamående, blodblandad urin',NULL,'2022-01-09 15:50:00'),('19931013-8350','Johan Johansson','Gatan 2','M','2021-12-01 00:00:00','2021-12-02 18:25:28','Kass i Magen',NULL,'2022-01-01 14:30:00'),('19980318-2964','Emmy Gunnarsson','Östra Förstadsgatan 22, 740 34, SKYTTORP','F','2021-12-01 00:00:00',NULL,'Ser dvärgar utanför fönstret samt säger att hon är Snövit','Nedstämd, allt känns tråkigt','2022-02-01 17:10:00'),('19981007-8296','Nathan Hellström','Fälloheden 32, 930 92, MELLANSTRÖM','M','2021-12-01 00:00:00',NULL,'Extrema smärtor i hals med feber ',NULL,'2022-02-03 16:20:00'),('20000704-3284','Rosa Göransson','Ovansjövägen 35, 812 00, STORVIK','F','2021-12-01 00:00:00',NULL,'Upplever massiva svettningar',NULL,'2021-12-07 08:20:00');
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
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

-- Dump completed on 2021-12-02 20:09:19

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
-- Temporary view structure for view `patients_critical_condition`
--

DROP TABLE IF EXISTS `patients_critical_condition`;
/*!50001 DROP VIEW IF EXISTS `patients_critical_condition`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `patients_critical_condition` AS SELECT 
 1 AS `ID`,
 1 AS `Name`,
 1 AS `Address`,
 1 AS `Gender`,
 1 AS `Admitted`,
 1 AS `Sent Home`,
 1 AS `Reason`,
 1 AS `History`,
 1 AS `Appointment`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `diagnosis_overview`
--

DROP TABLE IF EXISTS `diagnosis_overview`;
/*!50001 DROP VIEW IF EXISTS `diagnosis_overview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `diagnosis_overview` AS SELECT 
 1 AS `Patient ID`,
 1 AS `Diagnosis Name`,
 1 AS `Comments`,
 1 AS `Symtoms`,
 1 AS `Treatment`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `patients_rooms`
--

DROP TABLE IF EXISTS `patients_rooms`;
/*!50001 DROP VIEW IF EXISTS `patients_rooms`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `patients_rooms` AS SELECT 
 1 AS `Room`,
 1 AS `Name`,
 1 AS `ID`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `patients_doctors`
--

DROP TABLE IF EXISTS `patients_doctors`;
/*!50001 DROP VIEW IF EXISTS `patients_doctors`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `patients_doctors` AS SELECT 
 1 AS `Doctors Name`,
 1 AS `Patients Name`,
 1 AS `Patients ID`,
 1 AS `Patients Appointment`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vaccant_rooms`
--

DROP TABLE IF EXISTS `vaccant_rooms`;
/*!50001 DROP VIEW IF EXISTS `vaccant_rooms`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vaccant_rooms` AS SELECT 
 1 AS `Room`,
 1 AS `Vaccant`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `patients_critical_condition`
--

/*!50001 DROP VIEW IF EXISTS `patients_critical_condition`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`ulhpxhgnf5tkywq2`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `patients_critical_condition` AS select `patients`.`ID` AS `ID`,`patients`.`Name` AS `Name`,`patients`.`Address` AS `Address`,`patients`.`Gender` AS `Gender`,`patients`.`Admitted` AS `Admitted`,`patients`.`Senthome` AS `Sent Home`,`patients`.`Reason` AS `Reason`,`patients`.`History` AS `History`,`patients`.`Appointment` AS `Appointment` from `patients` where (`patients`.`Reason` like '%critical%') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `diagnosis_overview`
--

/*!50001 DROP VIEW IF EXISTS `diagnosis_overview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`ulhpxhgnf5tkywq2`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `diagnosis_overview` AS select `patients_has_diagnosis`.`patients_ID` AS `Patient ID`,`patients_has_diagnosis`.`diagnosis_Name` AS `Diagnosis Name`,`diagnosis`.`Comments` AS `Comments`,`diagnosis`.`Symtoms` AS `Symtoms`,`diagnosis`.`Treatment` AS `Treatment` from (`patients_has_diagnosis` join `diagnosis` on((`patients_has_diagnosis`.`diagnosis_Name` = `diagnosis`.`Name`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `patients_rooms`
--

/*!50001 DROP VIEW IF EXISTS `patients_rooms`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`ulhpxhgnf5tkywq2`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `patients_rooms` AS select `patients_has_rooms`.`rooms_ID` AS `Room`,`patients`.`Name` AS `Name`,`patients_has_rooms`.`patients_ID` AS `ID` from (`patients_has_rooms` join `patients` on((`patients_has_rooms`.`patients_ID` = `patients`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `patients_doctors`
--

/*!50001 DROP VIEW IF EXISTS `patients_doctors`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`ulhpxhgnf5tkywq2`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `patients_doctors` AS select `doctors`.`Name` AS `Doctors Name`,`patients`.`Name` AS `Patients Name`,`patients`.`ID` AS `Patients ID`,`patients`.`Appointment` AS `Patients Appointment` from (`patients` left join (`doctors_has_patients` left join `doctors` on((`doctors_has_patients`.`doctors_ID` = `doctors`.`ID`))) on((`doctors_has_patients`.`patients_ID` = `patients`.`ID`))) order by `patients`.`Appointment` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vaccant_rooms`
--

/*!50001 DROP VIEW IF EXISTS `vaccant_rooms`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`ulhpxhgnf5tkywq2`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vaccant_rooms` AS select `rooms`.`ID` AS `Room`,`rooms`.`Vaccant` AS `Vaccant` from `rooms` where (`rooms`.`Vaccant` = 'Yes') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-03 16:37:29

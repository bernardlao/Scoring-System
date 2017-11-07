-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: db_scoring
-- ------------------------------------------------------
-- Server version	5.6.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `tblcontestant`
--

LOCK TABLES `tblcontestant` WRITE;
/*!40000 ALTER TABLE `tblcontestant` DISABLE KEYS */;
INSERT INTO `tblcontestant` VALUES (1,'Qwe','C:\\\\Users\\\\Bernard Lao\\\\Documents\\\\Scoring System\\\\Images\\\\1.png',1,'qwe'),(2,'Leonardo','C:\\\\Users\\\\Bernard Lao\\\\Documents\\\\Scoring System\\\\Images\\\\2.png',2,'comsci');
/*!40000 ALTER TABLE `tblcontestant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tblcriteria`
--

LOCK TABLES `tblcriteria` WRITE;
/*!40000 ALTER TABLE `tblcriteria` DISABLE KEYS */;
INSERT INTO `tblcriteria` VALUES (1,'Qwe',10),(2,'Asd',10),(3,'Rty',10),(4,'Fgh',10),(5,'Vbn',10),(6,'Ipo',50);
/*!40000 ALTER TABLE `tblcriteria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tbljudge`
--

LOCK TABLES `tbljudge` WRITE;
/*!40000 ALTER TABLE `tbljudge` DISABLE KEYS */;
INSERT INTO `tbljudge` VALUES (1,'Qwe','qwe'),(2,'Leonardo Lao','captain');
/*!40000 ALTER TABLE `tbljudge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tblscoring`
--

LOCK TABLES `tblscoring` WRITE;
/*!40000 ALTER TABLE `tblscoring` DISABLE KEYS */;
INSERT INTO `tblscoring` VALUES (1,1,1,1,90,9),(2,1,2,1,90,9),(3,1,3,1,90,9),(4,1,4,1,90,9),(5,1,5,1,90,9),(6,1,6,1,90,45),(7,2,1,1,90,9),(8,2,2,1,90,9),(9,2,3,1,90,9),(10,2,4,1,90,9),(11,2,5,1,90,9),(12,2,6,1,90,45),(13,2,1,2,100,10),(14,2,2,2,100,10),(15,2,3,2,100,10),(16,2,4,2,100,10),(17,2,5,2,100,10),(18,2,6,2,100,50),(19,1,1,2,80,8),(20,1,2,2,80,8),(21,1,3,2,80,8),(22,1,4,2,80,8),(23,1,5,2,80,8),(24,1,6,2,80,40);
/*!40000 ALTER TABLE `tblscoring` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tbluser`
--

LOCK TABLES `tbluser` WRITE;
/*!40000 ALTER TABLE `tbluser` DISABLE KEYS */;
INSERT INTO `tbluser` VALUES (1,'admin','pass','Admin',NULL),(2,'qwe','qwe','Judge',1),(3,'leo','lao','Judge',2);
/*!40000 ALTER TABLE `tbluser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'db_scoring'
--
/*!50003 DROP FUNCTION IF EXISTS `IsDataNotExist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `IsDataNotExist`(tablename varchar(200),
								columnname varchar(200),
                                columnvalue varchar(200)) RETURNS tinyint(1)
BEGIN
DECLARE IsExist VARCHAR(300);
SELECT COUNT(*) INTO IsExist FROM tablename WHERE columnname = columnvalue;
CASE
	WHEN IsExist = '0' THEN RETURN TRUE;
    WHEN NOT IsExist = '0' THEN RETURN FALSE;
END CASE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_contestant` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_contestant`(fullname1 varchar(300),
									  photopath1 varchar(300),
                                      contestantno1 bigint,
                                      remarks1 varchar(300),
                                      isinsert bit,
                                      contestantid1 bigint)
BEGIN
CASE
	WHEN isinsert = 1 THEN INSERT INTO tblcontestant(fullname,photopath,contestantno,remarks) 
											VALUES(fullname1,photopath1,contestantno1,remarks1);
	WHEN isinsert = 0 THEN UPDATE tblcontestant SET fullname = fullname1, photopath = photopath1,
								contestantno = contestantno1, remarks = remarks1 WHERE contestantid = contestantid1;
end case;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_criteria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_criteria`(criterianame1 varchar(100),
									percentage1 double,
                                    isinsert tinyint(1),
                                    criteriaid1 bigint)
BEGIN
CASE
	WHEN isinsert = 1 THEN INSERT INTO tblcriteria(criterianame,percentage) 
							VALUES (criterianame1,percentage1);
	WHEN isinsert = 0 THEN UPDATE tblcriteria SET criterianame = criterianame1,
												  percentage = percentage1
											   WHERE criteriaid = criteriaid1;
end case;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_judge` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_judge`(fullname1 varchar(200),
								 remarks1 varchar(300),
                                 isinsert bit,
                                 judgeid1 bigint)
BEGIN
CASE 
	WHEN isinsert = 1 THEN INSERT INTO tbljudge (fullname,remarks) VALUES(fullname1,remarks1);
    WHEN isinsert = 0 THEN UPDATE tbljudge SET fullname = fullname1, remarks = remarks1 
								WHERE judgeid = judgeid1;
end case;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_user` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_user`(username1 varchar(100),
								userpassword1 varchar(100),
                                usertype1 varchar(100),
                                judgeid1 bigint,
								isinsert bit,
                                userid1 bigint)
BEGIN
CASE 
	WHEN isinsert = 1 THEN INSERT INTO tbluser (username,userpassword,usertype,judgeid) VALUES(username1,userpassword1,usertype1,if(judgeid1 = 0,null,judgeid1));
    WHEN isinsert = 0 THEN UPDATE tbluser SET username = username1, userpassword = userpassword1,
 												  usertype = usertype1, judgeid = judgeid1 WHERE userid = userid1;
end case;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-08  1:37:47

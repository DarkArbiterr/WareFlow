CREATE DATABASE  IF NOT EXISTS `wareflow` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `wareflow`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: wareflow
-- ------------------------------------------------------
-- Server version	8.0.21

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

--
-- Table structure for table `delivery`
--

DROP TABLE IF EXISTS `delivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `delivery` (
  `deliveryId` int NOT NULL,
  `warehouseId` int NOT NULL,
  `date` datetime(6) NOT NULL,
  PRIMARY KEY (`deliveryId`),
  KEY `warehouseId` (`warehouseId`),
  CONSTRAINT `delivery_ibfk_1` FOREIGN KEY (`warehouseId`) REFERENCES `warehouse` (`warehouseId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery`
--

LOCK TABLES `delivery` WRITE;
/*!40000 ALTER TABLE `delivery` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `productId` int NOT NULL,
  `name` varchar(16) NOT NULL,
  `desc` varchar(128) NOT NULL,
  PRIMARY KEY (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productdelivery`
--

DROP TABLE IF EXISTS `productdelivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdelivery` (
  `deliveryId` int NOT NULL,
  `productId` int NOT NULL,
  KEY `deliveryId` (`deliveryId`),
  KEY `productId` (`productId`),
  CONSTRAINT `productdelivery_ibfk_1` FOREIGN KEY (`deliveryId`) REFERENCES `delivery` (`deliveryId`),
  CONSTRAINT `productdelivery_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `product` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdelivery`
--

LOCK TABLES `productdelivery` WRITE;
/*!40000 ALTER TABLE `productdelivery` DISABLE KEYS */;
/*!40000 ALTER TABLE `productdelivery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productremoval`
--

DROP TABLE IF EXISTS `productremoval`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productremoval` (
  `removalId` int NOT NULL,
  `productId` int NOT NULL,
  KEY `removalId` (`removalId`),
  KEY `productId` (`productId`),
  CONSTRAINT `productremoval_ibfk_1` FOREIGN KEY (`removalId`) REFERENCES `removal` (`removalId`),
  CONSTRAINT `productremoval_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `product` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productremoval`
--

LOCK TABLES `productremoval` WRITE;
/*!40000 ALTER TABLE `productremoval` DISABLE KEYS */;
/*!40000 ALTER TABLE `productremoval` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productwarehouse`
--

DROP TABLE IF EXISTS `productwarehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productwarehouse` (
  `warehouseId` int NOT NULL,
  `productId` int NOT NULL,
  KEY `warehouseId` (`warehouseId`),
  KEY `productId` (`productId`),
  CONSTRAINT `productwarehouse_ibfk_1` FOREIGN KEY (`warehouseId`) REFERENCES `warehouse` (`warehouseId`),
  CONSTRAINT `productwarehouse_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `product` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productwarehouse`
--

LOCK TABLES `productwarehouse` WRITE;
/*!40000 ALTER TABLE `productwarehouse` DISABLE KEYS */;
/*!40000 ALTER TABLE `productwarehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `removal`
--

DROP TABLE IF EXISTS `removal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `removal` (
  `removalId` int NOT NULL,
  `warehouseId` int NOT NULL,
  `date` datetime(6) NOT NULL,
  PRIMARY KEY (`removalId`),
  KEY `warehouseId` (`warehouseId`),
  CONSTRAINT `removal_ibfk_1` FOREIGN KEY (`warehouseId`) REFERENCES `warehouse` (`warehouseId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `removal`
--

LOCK TABLES `removal` WRITE;
/*!40000 ALTER TABLE `removal` DISABLE KEYS */;
/*!40000 ALTER TABLE `removal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `email` varchar(32) NOT NULL,
  `password` varchar(64) NOT NULL,
  `firstName` varchar(16) NOT NULL,
  `secondName` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse`
--

DROP TABLE IF EXISTS `warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `warehouse` (
  `userId` int NOT NULL,
  `warehouseId` int NOT NULL,
  `name` varchar(16) NOT NULL,
  PRIMARY KEY (`warehouseId`),
  KEY `userId` (`userId`),
  CONSTRAINT `warehouse_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse`
--

LOCK TABLES `warehouse` WRITE;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-10  2:40:43

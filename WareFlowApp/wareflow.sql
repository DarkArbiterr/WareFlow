CREATE DATABASE  IF NOT EXISTS `wareflow`
USE `wareflow`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: wareflow
-- ------------------------------------------------------
-- Server version	8.1.0

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
INSERT INTO `delivery` VALUES (1,1,'2023-08-11 18:38:19.000000'),(2,1,'2023-08-10 18:38:19.000000'),(3,2,'2023-08-09 18:38:19.000000'),(4,3,'2023-08-08 18:38:19.000000'),(5,3,'2023-08-07 18:38:19.000000');
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
INSERT INTO `product` VALUES (1,'Laptop','High-performance laptop for professionals'),(2,'Smartphone','Latest flagship smartphone with advanced features'),(3,'Monitor','27\" IPS monitor with full HD resolution'),(4,'Printer','Color inkjet printer for home and office use'),(5,'Wireless Mouse','Ergonomic wireless mouse for better productivity');
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
INSERT INTO `productdelivery` VALUES (1,1),(1,2),(2,3),(3,4),(4,5);
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
INSERT INTO `productremoval` VALUES (1,1),(1,2),(2,3),(3,4),(4,5);
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
INSERT INTO `productwarehouse` VALUES (1,1),(2,2),(1,3),(3,4),(2,5);
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
INSERT INTO `removal` VALUES (1,1,'2023-08-10 18:39:04.000000'),(2,1,'2023-08-09 18:39:04.000000'),(3,2,'2023-08-08 18:39:04.000000'),(4,3,'2023-08-07 18:39:04.000000'),(5,3,'2023-08-06 18:39:04.000000');
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'john.doe@example.com','5ebe2294ecd0e0f08eab7690d2a6ee69','John','Doe'),(2,'jane.smith@example.com','34819d7beeabb9260a5c854bc85b3e44','Jane','Smith'),(3,'michael.johnson@example.com','bb8be419bbfa7e13773c7df4c2ebce7f','Michael','Johnson'),(4,'emily.brown@example.com','6d6d6c0c8f1b3db34de84374a931311c','Emily','Brown'),(5,'david.wilson@example.com','52f6d15043808a81058a426b30649d8f','David','Wilson');
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
INSERT INTO `warehouse` VALUES (1,1,'Main'),(2,2,'Regional_1A'),(3,3,'Regional_1B');
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

-- Dump completed on 2023-08-11 20:22:07

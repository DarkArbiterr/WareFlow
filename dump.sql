CREATE TABLE `Users` (
	`userId` INT(8) NOT NULL AUTO_INCREMENT,
	`email` VARCHAR(32) NOT NULL,
	`password` VARCHAR(64) NOT NULL,
	`firstName` VARCHAR(16) NOT NULL,
	`secondName` VARCHAR(32),
	PRIMARY KEY (`userId`)
);

CREATE TABLE `Warehouse` (
	`userId` INT(8) NOT NULL,
	`warehouseId` INT(8) NOT NULL,
	`name` VARCHAR(16) NOT NULL,
	PRIMARY KEY (`warehouseId`)
);

CREATE TABLE `Products` (
	`productId` INT(8) NOT NULL,
	`name` VARCHAR(16) NOT NULL,
    `desc` VARCHAR(128) NOT NULL,
	PRIMARY KEY (`productId`)
);

CREATE TABLE `Deliveries` (
	`deliveryId` INT(8) NOT NULL,
	`warehouseId` INT(8) NOT NULL,
	`date` DATETIME(16) NOT NULL,
	PRIMARY KEY (`deliveryId`)
);

CREATE TABLE `ProductDeliveries` (
	`deliveryId` INT(8) NOT NULL,
	`productId` INT(8) NOT NULL,
);

CREATE TABLE `Removals` (
	`removalId` INT(8) NOT NULL,
	`warehouseId` INT(8) NOT NULL,
	`date` DATETIME(16) NOT NULL,
	PRIMARY KEY (`removalId`)
);

CREATE TABLE `ProductRemovals` (
	`removalId` INT(8) NOT NULL,
	`productId` INT(8) NOT NULL,
);

CREATE TABLE `ProductWarehouses` (
	`warehouseId` INT(8) NOT NULL,
	`productId` INT(8) NOT NULL,
);
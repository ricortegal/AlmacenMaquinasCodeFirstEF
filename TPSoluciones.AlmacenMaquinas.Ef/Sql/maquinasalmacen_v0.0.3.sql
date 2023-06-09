
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `almacen_ubicaciones` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Pasillo` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Estanteria` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Altura` int NOT NULL,
    `Posicion` int NOT NULL,
    `FechaEntrada` datetime(6) NOT NULL,
    `FechaSalida` datetime(6) NULL,
    CONSTRAINT `PK_almacen_ubicaciones` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `clientes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nombre` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Direccion` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Poblacion` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Telefono` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Email` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_clientes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `productos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Codigo` varchar(15) CHARACTER SET utf8mb4 NOT NULL,
    `Nombre` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `Descripcion` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_productos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `articulos` (
    `NumSerie` varchar(15) CHARACTER SET utf8mb4 NOT NULL,
    `NotasFabricacion` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `NotasRecepcion` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `NotasInstalacion` TINYTEXT CHARACTER SET utf8mb4 NOT NULL,
    `FechaFabricacion` datetime(6) NOT NULL,
    `FechaRecepcion` datetime(6) NOT NULL,
    `FechaInstalacion` datetime(6) NULL,
    `IdProducto` int NOT NULL,
    `IdUbicacion` int NOT NULL,
    CONSTRAINT `PK_articulos` PRIMARY KEY (`NumSerie`),
    CONSTRAINT `FK_articulos_almacen_ubicaciones_IdUbicacion` FOREIGN KEY (`IdUbicacion`) REFERENCES `almacen_ubicaciones` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_articulos_productos_IdProducto` FOREIGN KEY (`IdProducto`) REFERENCES `productos` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ventas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Fecha` datetime(6) NOT NULL,
    `IdCliente` int NOT NULL,
    `Precio` decimal(65,30) NOT NULL,
    `NumSerieArticulo` varchar(15) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ventas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ventas_articulos_NumSerieArticulo` FOREIGN KEY (`NumSerieArticulo`) REFERENCES `articulos` (`NumSerie`),
    CONSTRAINT `FK_ventas_clientes_IdCliente` FOREIGN KEY (`IdCliente`) REFERENCES `clientes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_articulos_IdProducto` ON `articulos` (`IdProducto`);

CREATE INDEX `IX_articulos_IdUbicacion` ON `articulos` (`IdUbicacion`);

CREATE UNIQUE INDEX `IX_productos_Codigo` ON `productos` (`Codigo`);

CREATE INDEX `IX_ventas_IdCliente` ON `ventas` (`IdCliente`);

CREATE UNIQUE INDEX `IX_ventas_NumSerieArticulo` ON `ventas` (`NumSerieArticulo`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230415235510_MigracionInicial', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE `productos` ADD `FechaAlta` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230416000407_v0.0.2_AddFechaAltaArticulo', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE `clientes` ADD `Cp` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230416134212_v0.0.3_CpClienteEraPrivado', '7.0.5');

COMMIT;



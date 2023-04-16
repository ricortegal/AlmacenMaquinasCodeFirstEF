-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.11.2-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para maquinasalmacen
CREATE DATABASE IF NOT EXISTS `maquinasalmacen` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `maquinasalmacen`;

-- Volcando estructura para tabla maquinasalmacen.almacen_ubicaciones
CREATE TABLE IF NOT EXISTS `almacen_ubicaciones` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Pasillo` tinytext NOT NULL,
  `Estanteria` tinytext NOT NULL,
  `Altura` int(11) NOT NULL,
  `Posicion` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8009 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla maquinasalmacen.articulos
CREATE TABLE IF NOT EXISTS `articulos` (
  `NumSerie` varchar(15) NOT NULL,
  `NotasFabricacion` tinytext NOT NULL,
  `NotasRecepcion` tinytext NOT NULL,
  `NotasInstalacion` tinytext NOT NULL,
  `FechaFabricacion` datetime(6) NOT NULL,
  `FechaRecepcion` datetime(6) NOT NULL,
  `FechaInstalacion` datetime(6) DEFAULT NULL,
  `IdProducto` int(11) NOT NULL,
  `IdUbicacion` int(11) NOT NULL,
  PRIMARY KEY (`NumSerie`),
  KEY `IX_articulos_IdProducto` (`IdProducto`),
  KEY `IX_articulos_IdUbicacion` (`IdUbicacion`),
  CONSTRAINT `FK_articulos_almacen_ubicaciones_IdUbicacion` FOREIGN KEY (`IdUbicacion`) REFERENCES `almacen_ubicaciones` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_articulos_productos_IdProducto` FOREIGN KEY (`IdProducto`) REFERENCES `productos` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla maquinasalmacen.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` tinytext NOT NULL,
  `Direccion` tinytext NOT NULL,
  `Poblacion` tinytext NOT NULL,
  `Telefono` longtext NOT NULL,
  `Email` tinytext NOT NULL,
  `Cp` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2001 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla maquinasalmacen.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(15) NOT NULL,
  `Nombre` tinytext NOT NULL,
  `Descripcion` longtext NOT NULL,
  `FechaAlta` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_productos_Codigo` (`Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla maquinasalmacen.ventas
CREATE TABLE IF NOT EXISTS `ventas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` datetime(6) NOT NULL,
  `IdCliente` int(11) NOT NULL,
  `Precio` decimal(65,30) NOT NULL,
  `NumSerieArticulo` varchar(15) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_ventas_NumSerieArticulo` (`NumSerieArticulo`),
  KEY `IX_ventas_IdCliente` (`IdCliente`),
  CONSTRAINT `FK_ventas_articulos_NumSerieArticulo` FOREIGN KEY (`NumSerieArticulo`) REFERENCES `articulos` (`NumSerie`) ON DELETE CASCADE,
  CONSTRAINT `FK_ventas_clientes_IdCliente` FOREIGN KEY (`IdCliente`) REFERENCES `clientes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2086 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla maquinasalmacen.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- La exportación de datos fue deseleccionada.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

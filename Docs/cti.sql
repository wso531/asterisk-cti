/*
SQLyog Community Edition- MySQL GUI v5.23
Host - 5.0.44-log : Database - test
*********************************************************************
Server version : 5.0.44-log
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

create database if not exists `test`;

USE `test`;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

/*Table structure for table `cti` */

DROP TABLE IF EXISTS `cti`;

CREATE TABLE `cti` (
  `USERNAME` varchar(255) default NULL,
  `SECRET` varchar(255) default NULL,
  `HOST` varchar(255) default NULL,
  `EXT` varchar(255) default NULL,
  UNIQUE KEY `USERNAME` (`USERNAME`),
  UNIQUE KEY `EXT` (`EXT`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `cti` */

insert  into `cti`(`USERNAME`,`SECRET`,`HOST`,`EXT`) values ('test','098f6bcd4621d373cade4e832627b4f6','0.0.0.0','SIP/300');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;

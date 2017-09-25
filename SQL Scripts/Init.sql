CREATE SCHEMA IF NOT EXISTS `acedemy`;
USE `acedemy`;

CREATE TABLE IF NOT EXISTS Users
(
	Id bigint,
    Username VARCHAR(100),
    `Password` VARCHAR(100),
    Primary key (id)
);


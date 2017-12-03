CREATE SCHEMA IF NOT EXISTS `bcompliantsolutions`;
USE `bcompliantsolutions`;

CREATE TABLE IF NOT EXISTS users(
  id bigint,
   username varchar(100),
  password varchar(100),
  primary	key (id)
)


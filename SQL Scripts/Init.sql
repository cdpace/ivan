CREATE SCHEMA IF NOT EXISTS `bcompliantsolutions`;
USE `bcompliantsolutions`;

	CREATE TABLE IF NOT EXISTS address(
 id bigint,
 addressline1 varchar(100),
 addressline2 varchar(100),
 town varchar(50),
 postCode varchar(50),
 country varchar(50),
 primary key (id)
);


CREATE TABLE IF NOT EXISTS users(
  id bigint,
   username varchar(100),
  password varchar(100),
  addressid bigint,
  primary	key (id),
  constraint dk_test foreign key (addressid) references address (id)
);



USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

Create Table BreweryAddress
(
	addressId int Identity(1,1) not null,
	streetAddress varchar(255) not null,
	city varchar(255) not null,
	stateOrTerritory varchar(255) not null,
	country varchar(255) not null,
	postalCode varchar(25) null

	constraint pk_addressId primary key (addressId)
);

Create Table Brewery
(
	breweryId int Identity(1000, 1) not null,
	breweryName varchar(500) not null,
	addressId int not null,
	phoneNumber varchar(14) not null,
	website varchar(5000) not null,
	history varchar(8000),
	beerListId int not null

	constraint pk_breweryId primary key (breweryId),
	constraint fk_addressId foreign key (addressId) references BreweryAddress(addressId)
);

Create Table Beer
(
	beerId int Identity(1000, 1) not null,
	beerName varchar(300) not null,
	beerType varchar(100) not null,
	abv int not null,
	beerDescription varchar(1000),
	beerBreweryId int not null

	constraint pk_beerId primary key (beerId),
	constraint fk_beerBreweryId foreign key (beerBreweryId) references Brewery(breweryId)
);

Create Table UserBrewery 
(
	userId int not null,
	breweryId int not null,

	constraint fk_userId foreign key (userId) references users(user_id),
	constraint fk_breweryId foreign key (breweryId) references Brewery(breweryId)
);
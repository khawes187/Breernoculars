Use Master

Create Database Beernoculars

Use Beernoculars

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


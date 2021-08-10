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
	addressId int Identity(1, 1) not null,
	streetAddress varchar(255) not null,
	city varchar(255) not null,
	stateOrTerritory varchar(255) not null,
	country varchar(255) not null,
	postalCode varchar(25) null

	constraint pk_addressId primary key (addressId)
);

Create Table Brewery
(
	breweryId int Identity(100, 1) not null,
	breweryName varchar(500) not null,
	breweryAddressId int not null,
	phoneNumber varchar(14) not null,
	website varchar(5000) not null,
	dateEstablished varchar(4) not null,
	history varchar(8000),
	approved BIT not null

	constraint pk_breweryId primary key (breweryId),
	constraint fk_addressId foreign key (breweryAddressId) references BreweryAddress(addressId)
);

Create Table Beer
(
	beerId int Identity(1000, 1) not null,
	beerName varchar(300) not null,
	beerType varchar(100) not null,
	abv decimal not null,
	beerDescription varchar(1000),
	beerBreweryId int not null,
	seasonal varchar(50)

	constraint pk_beerId primary key (beerId),
	constraint fk_beerBreweryId foreign key (beerBreweryId) references Brewery(breweryId)
);

Create Table UserBrewery 
(
	userBrewery int Identity(100, 1) not null,
	userId int not null,
	breweryId int not null

	constraint pk_userBrewery primary key (userBrewery),
	constraint fk_userId foreign key (userId) references users(user_id),
	constraint fk_breweryId foreign key (breweryId) references Brewery(breweryId)
);

Create Table UserReviews
(
	beerReviewId int Identity (1, 1) not null,
	userId int not null,
	beerId int not null,
	rating decimal not null,
	reviewBody varchar (6000),

	constraint pk_beerReviewId primary key (beerReviewId),
	constraint fk_userIdRate foreign key (userId) references users(user_id),
	constraint fk_beerIdRate foreign key (beerId) references Beer(beerId),
	constraint chk_rating check (rating>=0.0 and rating<=5.0)
);

INSERT INTO dbo.BreweryAddress 
(streetAddress, city, stateOrTerritory, country, postalCode)
VALUES
('2885 Detroit Ave', 'Cleveland', 'OH', 'USA', '44113'),
('7524 Father Frascati', 'Cleveland', 'OH', 'USA', '44102'),
('2516 Market Ave', 'Cleveland', 'OH', 'USA', '44113'),
('1261 Superior Ave', 'Cleveland', 'OH', 'USA', '44114'),
('4125 Lorain Ave.', 'Cleveland', 'OH', 'USA', '44113')

INSERT INTO dbo.Brewery
(breweryName, breweryAddressId, phoneNumber, website, dateEstablished, history, approved)
VALUES
('Saucy Brew Works', (SELECT addressId FROM dbo.BreweryAddress WHERE BreweryAddress.streetAddress = '2885 Detroit Ave' AND BreweryAddress.postalCode = '44113'), '(216) 666-2568', 'https://www.saucybrewworks.com/cleveland-brewpub/', '2017', 'For Saucy Brew Works, respect for community means being responsible with our resources. The brewery’s systems reduce water use and pre-treat wastewater. Fresh Fork Market uses our spent grains to feed their animals. We in turn will buy their meat — and the world goes round. Respect also means supporting education. Not only about the world of beer, but educating the next generation of bright minds. That’s why we support Breakthrough Schools, a top performing charter school network in our community that takes a different approach to education. Just like we take a different approach to beer.', 1),
('Terrestrial Brewing Company', (SELECT addressId FROM dbo.BreweryAddress WHERE BreweryAddress.streetAddress = '7524 Father Frascati' AND BreweryAddress.postalCode = '44102'), '(216) 465-9999', 'https://www.facebook.com/terrestrialbrewing/', 'unkn', 'Small-batch brewery boasting unique beers and amazing views of Lake Erie in the Battery Park neighborhood. Owners: Ryan Bennett, Ralph Sgro. Head Brewer: Ralph Sgro', 1),
('Great Lakes Brewing Company', (SELECT addressId FROM dbo.BreweryAddress WHERE BreweryAddress.streetAddress = '2516 Market Ave' AND BreweryAddress.postalCode = '44113'), '(216) 771-4404', 'https://www.greatlakesbrewing.com', '1986', 'Two Irish brothers with limited brewing experience. A city that shuttered its last production brewery in the early 80s. A neighborhood in serious need of a facelift. In 1986 when Patrick and Daniel Conway opened their fledgling operation in Cleveland''s Ohio City neighborhood, the odds were stacked against them. Fortunately, they surrounded themselves with a staff of passionate, knowledgeable people, and from the start committed themselves to bringing a sophisticated, diverse selection of craft beer to their home state. Two decades, multiple awards, and a whole lot of stories later, Pat and Dan Conway celebrate over two decades of brewing exceptional beer for their adventurous and discerning customers.', 1),
('Masthead Brewing Company', (SELECT addressId FROM dbo.BreweryAddress WHERE BreweryAddress.streetAddress = '1261 Superior Ave' AND BreweryAddress.postalCode = '44114'), '(216) 206-6176', 'https://www.mastheadbrewingco.com', '2017', 'Masthead Brewing Company is located in the historic Bryant Building at 1261 Superior Avenue in downtown Cleveland. Our building was originally built in 1921 as an automotive dealership and is now listed on the National Register of Historic Places. The taproom features 300 seats, a 100’ long bar, and an additional 50 seat dog friendly patio with a view of downtown Cleveland. We’ve become known for our ever evolving lineup of juicy New England IPAs, Neapolitan-style pizza, and our barrel aged beer utilizing exclusively allocated whiskey barrels from top-rated distilleries.', 1),
('Platform Beer Company', (SELECT addressId FROM dbo.BreweryAddress WHERE BreweryAddress.streetAddress = '4125 Lorain Ave.' AND BreweryAddress.postalCode = '44114'), '(216) 202-1386', 'https://platformbeer.co', '2014', 'Platform was founded in 2014 on the premise that collaboration should be at the cornerstone of everything that we do. Whether it be with pro brewers, the home brewing world or a variety of other industries, beer is special and should be shared. From humble beginnings, brewing on a 3 bbl brewhouse in Cleveland, Platform has expanded to a second tasting room in Columbus, a production facility in Cleveland, a Cincinnati tasting room named LOCOBA and a sour beer facility in Cleveland named Phunkenship. We brew high-quality craft beers for sale in our tasting rooms and distribute throughout Ohio, Indiana, Kentucky, Pennsylvania, New York City, Connecticut, and New Jersey. Platform Beer Co. products can be found at grocery stores and craft bottle shops. Expect a mix of ever-changing styles inspired by beer trends.', 1)

INSERT INTO dbo.Beer
(beerName, beerType, abv, beerDescription, beerBreweryId, seasonal)
VALUES
('Habituale', 'Kolsch Style Golden Ale', 5.0, 'Light, clean, crisp with a slight citrusy spicy character.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Saucy Brew Works' AND brewery.phoneNumber = '(216) 666-2568'), 'no'),
('Juicy ASAP', 'American IPA', 6.5, 'Tropical, citrusy, and most certainly juicy.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Saucy Brew Works' AND brewery.phoneNumber = '(216) 666-2568'), 'no'),
('Space Chimp Wit OG', 'Wheat Beer - Witbier', 5.0, 'Our original gangster, Space Chimp Wit, brewed with bitter orange and coriander.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Terrestrial Brewing Company' AND brewery.phoneNumber = '(216) 465-9999'), 'no'),
('Evenstar', 'American IPA', 7.4, 'A West Coast Style IPA brewed with Simcoe, Nugget, Centennial and Citra hops. Dry and resinous with a fruity and bitter finish.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Terrestrial Brewing Company' AND brewery.phoneNumber = '(216) 465-9999'), 'no')

INSERT INTO dbo.UserReviews
(userId, beerId, rating, reviewBody)
VALUES
(1, 1000, 4.2, 'Habituale is a solid kolsch. It pours a chill hazed pale straw with a decent head of white foam that settles to a thick fine beaded ring and a thin dusty layer with light lacing. Nose of cracker, light breaded malts, and honey sweet malts with a touch of pear and grape notes. Flavors follow the nose with honey touched malts with breaded malts and a touch of dry cracker with some pear crispness amongst a touch of herbal hops. Nice mouth feel; medium light body, medium light carbonation, smooth, and lightly crisp with a subtle dryness on the rear. Overall, a SOLID brew from a new to me brewery.'),
(1, 1001, 4.8, 'I got a can of this beer off the single shelf from my local Giant Eagle store. It poured a clear golden with white head that is leaving some lace. The scent had dank citrus notes. The taste was nicely balanced and easy to drink with tropical fruit peel flavors. The mouthfeel was medium in body with good carbonation. Overall it is a solid beer.'),
(1, 1002, 3.9, 'Very traditional Belgian-style wheat with a great flavor profile. Good balance of clove and banana yeasty flavors. Well balanced overall, not too sweet. Well crafted!'),
(1, 1003, 4.5, 'Oooooowoooooooo hops. Holy cow. This checks all the boxes in what I expect from an IPA. Wowee. Bitterness and aftertaste hit you after. Good stuff. Yep.')

SELECT * FROM dbo.BreweryAddress

SELECT * FROM dbo.Brewery

SELECT * FROM dbo.Beer

/* BREAK GLASS IN CASE OF EMERGENCY: */

/*
DELETE FROM dbo.BreweryAddress
DELETE FROM dbo.Brewery
DELETE FROM dbo.Beer
DELETE FROM dbo.UserBrewery
DROP TABLE dbo.BreweryAddress
DROP TABLE dbo.Brewery
DROP TABLE dbo.Beer
DROP TABLE dbo.UserBrewery

*/
SELECT brewery.breweryName, brewery.breweryId, brewery.phoneNumber, brewery.dateEstablished, brewery.history FROM Brewery WHERE breweryId = 100

SELECT beerName, beerType, abv, beerDescription, seasonal FROM dbo.Beer WHERE beerId = 1000

SELECT * FROM Brewery

UPDATE dbo.Brewery SET breweryName = 'ploop', breweryAddressId = 3, phoneNumber = '(216) 666-MILK', website = 'https://woooooooops', dateEstablished = '9999', history = 'never' WHERE breweryId = 102

SELECT * FROM Brewery

SELECT * FROM Beer

DELETE FROM dbo.Beer WHERE beer.beerId = 1005
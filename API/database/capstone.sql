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

Create Table Brewery
(
	breweryId int Identity(100, 1) not null,
	breweryName varchar(500) not null,
	breweryAddress varchar(500) not null,
	phoneNumber varchar(14) not null,
	website varchar(5000) not null,
	dateEstablished varchar(4) not null,
	history varchar(8000),
	approved BIT not null,
	breweryUrl nvarchar(4000)

	constraint pk_breweryId primary key (breweryId),	
);

Create Table Beer
(
	beerId int Identity(1000, 1) not null,
	beerName varchar(300) not null,
	beerType varchar(100) not null,
	abv decimal not null,
	beerDescription varchar(1000),
	beerBreweryId int not null,
	seasonal varchar(50),
	BeerUrl nvarchar (4000)

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



INSERT INTO dbo.Brewery
(breweryName, breweryAddress, phoneNumber, website, dateEstablished, history, approved, breweryUrl)
VALUES
('Saucy Brew Works', '2885 Detroit Ave Cleveland, OH 44113', '(216) 666-2568', 'https://www.saucybrewworks.com/cleveland-brewpub/', '2017', 'For Saucy Brew Works, respect for community means being responsible with our resources. The brewery’s systems reduce water use and pre-treat wastewater. Fresh Fork Market uses our spent grains to feed their animals. We in turn will buy their meat — and the world goes round. Respect also means supporting education. Not only about the world of beer, but educating the next generation of bright minds. That’s why we support Breakthrough Schools, a top performing charter school network in our community that takes a different approach to education. Just like we take a different approach to beer.', 1, 'https://www.saucybrewworks.com/media/images/Pinecrest.max-1000x1000.jpg'),
('Terrestrial Brewing Company', '7524 Father Frascati Cleveland, OH 44102', '(216) 465-9999', 'https://www.facebook.com/terrestrialbrewing/', 'unkn', 'Small-batch brewery boasting unique beers and amazing views of Lake Erie in the Battery Park neighborhood. Owners: Ryan Bennett, Ralph Sgro. Head Brewer: Ralph Sgro', 1, 'https://weare.techohio.ohio.gov/wp-content/uploads/2018/04/04-tbc1.jpg'),
('Great Lakes Brewing Company', '2516 Market Ave Cleveland, OH 44113', '(216) 771-4404', 'https://www.greatlakesbrewing.com', '1986', 'Two Irish brothers with limited brewing experience. A city that shuttered its last production brewery in the early 80s. A neighborhood in serious need of a facelift. In 1986 when Patrick and Daniel Conway opened their fledgling operation in Cleveland''s Ohio City neighborhood, the odds were stacked against them. Fortunately, they surrounded themselves with a staff of passionate, knowledgeable people, and from the start committed themselves to bringing a sophisticated, diverse selection of craft beer to their home state. Two decades, multiple awards, and a whole lot of stories later, Pat and Dan Conway celebrate over two decades of brewing exceptional beer for their adventurous and discerning customers.', 1, 'https://www.greatlakesbrewing.com/sites/default/files/glbc_blue_jackets.jpg'),
('Masthead Brewing Company', '1261 Superior Ave Cleveland, OH 44114', '(216) 206-6176', 'https://www.mastheadbrewingco.com', '2017', 'Masthead Brewing Company is located in the historic Bryant Building at 1261 Superior Avenue in downtown Cleveland. Our building was originally built in 1921 as an automotive dealership and is now listed on the National Register of Historic Places. The taproom features 300 seats, a 100’ long bar, and an additional 50 seat dog friendly patio with a view of downtown Cleveland. We’ve become known for our ever evolving lineup of juicy New England IPAs, Neapolitan-style pizza, and our barrel aged beer utilizing exclusively allocated whiskey barrels from top-rated distilleries.', 1, 'https://mastheadbrewingco.com/wp-content/uploads/2019/12/MJC6912-scaled.jpg'),
('Platform Beer Company', '4125 Lorain Ave Cleveland, OH 44113', '(216) 202-1386', 'https://platformbeer.co', '2014', 'Platform was founded in 2014 on the premise that collaboration should be at the cornerstone of everything that we do. Whether it be with pro brewers, the home brewing world or a variety of other industries, beer is special and should be shared. From humble beginnings, brewing on a 3 bbl brewhouse in Cleveland, Platform has expanded to a second tasting room in Columbus, a production facility in Cleveland, a Cincinnati tasting room named LOCOBA and a sour beer facility in Cleveland named Phunkenship. We brew high-quality craft beers for sale in our tasting rooms and distribute throughout Ohio, Indiana, Kentucky, Pennsylvania, New York City, Connecticut, and New Jersey. Platform Beer Co. products can be found at grocery stores and craft bottle shops. Expect a mix of ever-changing styles inspired by beer trends.', 1, 'https://images.squarespace-cdn.com/content/v1/58e90d0e20099ea6eba14db3/1578670701733-CFAATUHVCDVG65PHGLJA/platform2.jpg')

INSERT INTO dbo.Beer
(beerName, beerType, abv, beerDescription, beerBreweryId, seasonal, beerUrl)
VALUES
('Habituale', 'Kolsch Style Golden Ale', 5.0, 'Light, clean, crisp with a slight citrusy spicy character.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Saucy Brew Works' AND brewery.phoneNumber = '(216) 666-2568'), 'no', 'https://cdn.shopify.com/s/files/1/0278/6495/7016/products/habituale1.png?v=1615488341'),
('Juicy ASAP', 'American IPA', 6.5, 'Tropical, citrusy, and most certainly juicy.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Saucy Brew Works' AND brewery.phoneNumber = '(216) 666-2568'), 'no', 'https://cdn.shopify.com/s/files/1/0278/6495/7016/products/juicyasap22.png?v=1615488038'),
('Space Chimp Wit OG', 'Wheat Beer - Witbier', 5.0, 'Our original gangster, Space Chimp Wit, brewed with bitter orange and coriander.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Terrestrial Brewing Company' AND brewery.phoneNumber = '(216) 465-9999'), 'no', 'https://untappd.akamaized.net/photos/2021_08_10/fbd160171635e4ed8d513c5630ed4f7a_raw.jpg'),
('Evenstar', 'American IPA', 7.4, 'A West Coast Style IPA brewed with Simcoe, Nugget, Centennial and Citra hops. Dry and resinous with a fruity and bitter finish.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Terrestrial Brewing Company' AND brewery.phoneNumber = '(216) 465-9999'), 'no', 'https://untappd.akamaized.net/photos/2021_08_07/0b63faa79737b43c86bd298578c3234b_raw.jpg'),
('Dortmunder Gold', 'Lager - European / Dortmunder Export', 5.8, 'A classic award-winning balance of sweet malt and dry hop flavors, proudly waving the flag for Cleveland and refreshing beer drinkers everywhere since 1988.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Great Lakes Brewing Company' AND brewery.phoneNumber = '(216) 771-4404'), 'no', 'https://www.greatlakesbrewing.com/sites/default/files/dort-04202021.png'),
('Edmund Fitzgerald', 'Porter - American', 6.0, 'Robust and complex, our Porter is a bittersweet tribute to the legendary freighter’s fallen crew—taken too soon when the gales of November came early.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Great Lakes Brewing Company' AND brewery.phoneNumber = '(216) 771-4404'), 'no', 'http://brewscale.com/wp-content/uploads/2015/07/IMG_2247-780x1040.jpg'),
('Hazecraft IPA', 'IPA - New England', 6.7, '3, 2, 1... we have haze! A cloudy cosmos of Azacca, Lemondrop, and Simcoe hops awaits exploration.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Great Lakes Brewing Company' AND brewery.phoneNumber = '(216) 771-4404'), 'no', 'https://www.porchdrinking.com/wp-content/uploads/2020/09/Hazecraft-Pour.jpg'),
('IPA', 'IPA - American', 6.8, 'This India Pale Ale is the culmination of hundreds of batches and countless recipe iterations. Upon opening this can, you''ll be greeted with aromas of bright grapefruit, zesty pine, and ripe passionfruit. The aromas give way to a smooth mouthfeel, soft bitterness, and the rich flavor of citrus and tropical fruits', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Masthead Brewing Company' AND brewery.phoneNumber = '(216) 206-6176'), 'no', 'https://i5.walmartimages.com/asr/371fd069-e3d5-453b-9a5b-2f714ff1f34d_1.935b5486cec98f4a423396b0f8b3e954.jpeg?odnWidth=612&odnHeight=612&odnBg=ffffff'),
('Double Fleeb Juice', 'IPA - New England', 8.0, 'We''ve optimized things at the brewery and are now able to extract twice as much Fleeb Juice per Fleeb. It takes a lot more rubbing during the extraction process, but we think it''s worth it. Double Fleeb Juice is a bigger version of our first New England IPA, Fleeb Juice. Expect more of that juicy character from some of our favorite new age American-grown hops accompanied by a silkier body and higher ABV. As always, enjoy with good company. Cheers!', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Masthead Brewing Company' AND brewery.phoneNumber = '(216) 206-6176'), 'no', 'https://mastheadbrewingco.com/wp-content/uploads/2017/11/DSC_7212.jpg'),
('Speed Merchant', 'IPA - White', 6.6, 'White IPA with fruity, tropical dry hops. White wheat gives a very pale color.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Platform Beer Company' AND brewery.phoneNumber = '(216) 202-1386'), 'no', 'https://1.bp.blogspot.com/--BYBzHTzAK0/XmQlwOcQhTI/AAAAAAABseI/-q6hbtgtOcMFpWHONbzu0VzegpngSnGowCLcBGAsYHQ/s1600/Platform%2BSpeed%2BMerchant%2BWhite%2BIPA.jpg'),
('Pride Martian', 'Sour - Other', 6.0, 'This Martian arrives not only as the secrets spill but just in time to celebrate PRIDE month! A tropical burst of summer, bustling with pronounced flavors of sweet watermelon, tangy pineapple, and candy cherry. Enjoy this tart slushee style sour knowing you’ve helped contribute to Stonewall Columbus.', (SELECT breweryId FROM dbo.Brewery WHERE brewery.breweryName = 'Platform Beer Company' AND brewery.phoneNumber = '(216) 202-1386'), 'yes', 'https://res.feednews.com/assets/v2/def72f9402a05501561a0745e5a357f1?width=1280&height=720&quality=hq&category=us_Food')


INSERT INTO dbo.UserReviews
(userId, beerId, rating, reviewBody)
VALUES
(1, 1000, 4.2, 'Habituale is a solid kolsch. It pours a chill hazed pale straw with a decent head of white foam that settles to a thick fine beaded ring and a thin dusty layer with light lacing. Nose of cracker, light breaded malts, and honey sweet malts with a touch of pear and grape notes. Flavors follow the nose with honey touched malts with breaded malts and a touch of dry cracker with some pear crispness amongst a touch of herbal hops. Nice mouth feel; medium light body, medium light carbonation, smooth, and lightly crisp with a subtle dryness on the rear. Overall, a SOLID brew from a new to me brewery.'),
(1, 1001, 4.8, 'I got a can of this beer off the single shelf from my local Giant Eagle store. It poured a clear golden with white head that is leaving some lace. The scent had dank citrus notes. The taste was nicely balanced and easy to drink with tropical fruit peel flavors. The mouthfeel was medium in body with good carbonation. Overall it is a solid beer.'),
(1, 1002, 3.9, 'Very traditional Belgian-style wheat with a great flavor profile. Good balance of clove and banana yeasty flavors. Well balanced overall, not too sweet. Well crafted!'),
(1, 1003, 4.5, 'Oooooowoooooooo hops. Holy cow. This checks all the boxes in what I expect from an IPA. Wowee. Bitterness and aftertaste hit you after. Good stuff. Yep.'),
(1, 1004, 4.9, 'Flavorful and refreshing, a long-time favorite summer beer for me. A year round fav, actually. Clear golden color, low to moderate carbonation, nice head dissolves pretty quickly, pleasing lacing, not too much. Moderately alchoholic, high fives. All in all, a superb, restrained brew, that doesn''t cry out for attention. But you realize that it deserves attention: perfect balance of malt and hops, (for a lager, that is). To me, the equal of some of the most enjoyable lagers I''ve had in Germany.'),
(1, 1005, 4.7, 'Deep syrupy smell with a hint of coffee and chocolate and licorice. I like carbonation and this delivers, every sip is accompanied with a crisp punch. Before I evaluate the flavors I experience the carbonation and I like that. Pours nicely into a glass. Dark body with creamy head and smoky flavor. I''m honestly surprised this is best in style bc I just picked it up randomly. FORTUNE FAVORS THE BOLD. This is a good beer, drink and be well.'),
(1, 1008, 4.0, 'A couple of 12 oz. cans fit into a clear glass liter mug, since the head, though tight and durable, didn''t overextend its welcome. Its color is a dense and dark orange-amber. The nose picks up a little hoppiness, but not in abundance and not much more. The glass lacing is minimal. There''s very little sweetness to the introduction, despite a decent amount of malts to the tongue. Self described as a NEIPA, that''s how it will be rated here. Unlike most in the category, there''s very little starchy contributions that compliment or take the edge off a hoppy and relatively high ABV brew. There is more alcohol in the finish than good NEIPAs that provide more proof than a 6.7% ABV. This is a far better than bad beer. It took Great Lakes a while to add to the list of hazy beers. They could have done better.'),
(1, 1006, 4.6, '16 ounce can into tulip glass, canned on 10/27/2017. Pours slightly hazy medium golden yellow color with a 1-2 finger fairly dense and rocky white head with awesome retention, that reduces to a nice cap that lasts. Nice dense foamy lacing clings on the glass, with a fair amount of streaming carbonation retaining the cap. Aromas of big tangerine, lemon, grapefruit, peach, pineapple, passion fruit, papaya, mango, melon, guava, berry, citrus peel/zest, light pepper, pine, honey, lightly toasted biscuit, herbal, and floral/grassy earthiness. Damn nice aromas with great balance and complexity of citrus/fruity/tropical hops and moderate bready malt notes; with great strength. Taste of big tangerine, lemon, grapefruit, peach, pineapple, passion fruit, papaya, mango, melon, guava, berry, citrus peel/zest, light pepper, pine, honey, lightly toasted biscuit, herbal, and floral/grassy earthiness. Light-moderate pine, citrus peel, herbal, grassy, spicy bitterness on the finish. Lingering notes of tangerine, lemon, grapefruit, peach, pineapple, passion fruit, papaya, mango, melon, guava, berry, citrus peel/rind, pepper, pine, honey, biscuit, and herbal/floral/grassy earthiness on the finish for a while. Great complexity, robustness, and balance of citrus/fruity/tropical hops and moderate bready malt flavors; with a great malt/bitterness balance, and zero lingering hop astringency after the finish. Light-moderate increasing dryness from bitterness. Medium carbonation and body; with a very smooth, moderately creamy/bready/sticky, and lightly resinous/rindy balanced mouthfeel that is great. Zero warming alcohol for 6.8%. Overall this is an excellent IPA. All around great complexity, robustness, and balance of citrus/fruity/tropical hops and moderate bready malt flavors; very smooth and easy to drink with the modestly bitter/drying finish. Very Midwest feeling style. Big juicy and fairly dank hop complexity; nice bready malt backbone, with adequate lingering dryness. A very enjoyable offering.'),
(1, 1007, 3.7, '16 FL OZ can, served in an oversized, stemless, wine glass. This beer pours like pineapple juice. It is topped with two inches of off white head that leaves spotty lacing. The smell is loaded with tropical fruit with hints of pine. It starts out with tropical fruit flavor. The finish is pine. That pine grows with each sip leaving an increasingly bitter taste in my mouth. Medium to full mouthfeel. This is a pretty good beer. It marries the fruit juice NEIPA with the bitter finish of a west coast IPA. Which may be how to style is supposed to taste. I''m just so used to the fruit juice bombs that Hoof releases every two weeks.'),
(1, 1009, 3.8, 'Bought in Ohio at a Trader Joe’s.
I love how all the grains and hops are listed on the side of the can.
Look is a nice bright yellow.
Smell is floral with the hops also present.
Taste is a bit bitter, but not too bad.
Feel is nice, a bit biting but refreshing.
Overall it’s not too shabby.'),
(1, 1010, 3.6, 'Nice dark amber color...not much nose .... There''s something I don''t quite like in the feel ... Too thin? Not sour enough for a sour? Not a bad brew but not my fave')

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
--this is our TestScript for Module Capstone

--delete database tables in this order: reservation, site, campground, park

DELETE FROM reservation;
DELETE FROM [site];
DELETE FROM campground;
DELETE FROM park;

--Build a stripped-down, "pristine" database by inserting fake values into existing tables in this order park, campground, site, reservation

--Create new Park
INSERT INTO park VALUES ('Test Park' , 'Atlantis' , '2019-02-24' , 10, 2, 'there is grass with trees here.');
DECLARE @parkId int = (SELECT @@IDENTITY);

--insert new campground
INSERT INTO campground VALUES (@parkId, 'LaLa Land', 5, 11, 25.00);
DECLARE @campgroundId int = (SELECT @@IDENTITY);

--insert new site
INSERT INTO [site] VALUES (@campgroundId, 3, 10, 1, 60, 1);
DECLARE @siteId int = (SELECT @@IDENTITY);

--insert new reservation
INSERT INTO reservation VALUES (@siteId, 'Flintstone' , '2019-01-15' , '2019-01-20' , '2019-01-01');
DECLARE @reservationId int =(SELECT @@IDENTITY);

SELECT @parkId as parkId, @campgroundId as campgroundId, @siteId as siteId, @reservationId as reservationId;

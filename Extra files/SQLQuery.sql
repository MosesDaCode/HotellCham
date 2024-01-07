SELECT 
	*
From
	Guests;

SELECT
	*
FROM
	Guests
ORDER BY
	LastName ASC;

SELECT 
	FirstName
FROM
	Guests
WHERE 
	FirstName = 'Mousa';

SELECT
	*
FROM
	Rooms
WHERE
	RoomType = 'DubbelRum';

SELECT 
	*
FROM 
	Rooms
ORDER BY
	PricePerNight DESC;

SELECT 
	RoomId, RoomNumber, AVG(PricePerNight) AS AvgPricePerNight
FROM 
	Rooms;


SELECT 
	RoomId, RoomNumber, PricePerNight
FROM
	Rooms
ORDER BY
	PricePerNight DESC;

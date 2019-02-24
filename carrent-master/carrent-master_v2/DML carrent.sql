USE carrent;

INSERT INTO Carclass (description, price)
VALUES
	 ('Station Wagon', 100)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 42226', 'Subaru', 'WRX STI', 1)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 30710', 'VW', 'Polo', 1)
;



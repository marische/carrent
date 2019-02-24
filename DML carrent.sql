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

INSERT INTO Customer (firstname, surname, street, zip, town, country, phone, mail, birthdate)
VALUES
	('Marina', 'Scherrer', 'Hintere Lortanne 5', '9053', 'Teufen', 'CH', '079 333 44 55', 'info@marina.ch', current_date())
;



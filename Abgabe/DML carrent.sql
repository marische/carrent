USE carrent;

INSERT INTO Carclass (description, price)
VALUES
	 ('Station Wagon', 100)
;

INSERT INTO Carclass (description, price)
VALUES
	 ('Sport Car', 200)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 4400', 'Subaru', 'WRX STI', 1)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 3300', 'Mitsubishi', 'Lancer Evolution', 1)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 2200', 'Ford', 'Focus RS', 1)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 1100', 'Audi', 'RS3', 1)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 990', 'Porsche', 'GT3 RS', 2)
;

INSERT INTO Car (licenseplate, brand, model, fk_carclass_id)
VALUES
	 ('AR 880', 'Lotus', 'Exige', 2)
;

INSERT INTO Customer (firstname, surname, street, zip, town, country, phone, mail, birthdate)
VALUES
	('Max', 'Muster', 'Musterstrasse 5', '9000', 'St. Gallen', 'CH', '079 333 44 55', 'info@muster.ch', current_date())
;

INSERT INTO Customer (firstname, surname, street, zip, town, country, phone, mail, birthdate)
VALUES
	('Anna', 'Meier', 'Hauptstrasse 10', '8000', 'Zürich', 'CH', '079 333 44 66', 'info@meier.ch', current_date())
;



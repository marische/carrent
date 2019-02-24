DROP DATABASE IF EXISTS carrent;

CREATE DATABASE carrent
	CHARACTER SET utf8;
    
USE carrent;

CREATE TABLE Customer
(
	customer_id INT AUTO_INCREMENT
    ,firstname VARCHAR(42) NOT NULL
    ,lastname VARCHAR(42) NOT NULL
    ,street VARCHAR(255) NOT NULL
    ,town VARCHAR(42) NOT NULL
    ,country VARCHAR(42) NOT NULL
    ,phonenumber VARCHAR(42) NOT NULL
    ,birthdate DATETIME NOT NULL
    
    ,PRIMARY KEY(customer_id)
);

CREATE TABLE Carclass
(
	carclass_id INT AUTO_INCREMENT
    ,description VARCHAR(42) NOT NULL
    ,price DECIMAL NOT NULL
    ,carcount INT NOT NULL DEFAULT 0
    
    ,PRIMARY KEY (carclass_id)
);
    
CREATE TABLE Car
(
	car_id INT AUTO_INCREMENT
	,licenseplate VARCHAR(10) NOT NULL
    ,brand VARCHAR(42) NOT NULL
    ,model VARCHAR(42) NOT NULL
    ,fk_carclass_id INT NOT NULL
    ,occupied BOOL NOT NULL DEFAULT FALSE

    ,PRIMARY KEY (car_id)
	,FOREIGN KEY (fk_carclass_id) REFERENCES carclass(carclass_id)
);


CREATE TABLE Reservation
(
	reservation_id INT AUTO_INCREMENT
    ,state ENUM('open', 'cancelled', 'completed') NOT NULL DEFAULT 'open'
    ,fk_customer_id INT NOT NULL
    ,fk_carclass_id INT NOT NULL
    ,startdate DATETIME NOT NULL
    ,enddate DATETIME NOT NULL
    ,bookingdate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
    ,totalamount DECIMAL NOT NULL
    
    ,PRIMARY KEY(reservation_id)
    ,FOREIGN KEY (fk_customer_id) REFERENCES Customer(customer_id)
    ,FOREIGN KEY (fk_carclass_id) REFERENCES Carclass(carclass_id)
);

CREATE TABLE CONTRACT
(
	contract_id INT AUTO_INCREMENT
    ,state ENUM('open', 'wait for return', 'closed') NOT NULL DEFAULT 'open'
    ,fk_customer_id INT NOT NULL
    ,fk_carclass_id INT NOT NULL
    ,startdate DATETIME NOT NULL
    ,enddate DATETIME NOT NULL
    ,contractdate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
    ,totalamount DECIMAL NOT NULL
    
    ,PRIMARY KEY (contract_id)
    ,FOREIGN KEY (fk_customer_id) REFERENCES Customer(customer_id)
    ,FOREIGN KEY (fk_carclass_id) REFERENCES Carclass(carclass_id)
);

CREATE TABLE Damage
(
	damage_id INT AUTO_INCREMENT
    ,fk_car_id INT NOT NULL
    ,fk_contract_id INT NOT NULL
    ,description VARCHAR(255) NOT NULL
    ,paid BOOL NOT NULL DEFAULT FALSE
    
    ,PRIMARY KEY(damage_id)
    ,FOREIGN KEY (fk_car_id) REFERENCES Car(car_id)
    ,FOREIGN KEY (fk_contract_id) REFERENCES Contract(contract_id)
);
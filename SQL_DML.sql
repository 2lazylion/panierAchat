
SET IDENTITY_INSERT Credentials ON
INSERT INTO credentials(credentials_id, username, password) VALUES(1, 'edward','cadet');
INSERT INTO credentials(credentials_id, username, password) VALUES(2, 'dominic','tardif');
SET IDENTITY_INSERT Credentials OFF

SET IDENTITY_INSERT Address ON
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(1, 11,'rue perdu', 'F1H1S5');
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(2, 22,'rue connaissance', 'F2H2S5');
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(3, 33,'rue illumine', 'F3H3S5');
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(4, 13,'rue du chemin', 'F6H6S5');
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(5, 9,'rue de la route', 'F9H9S5');
INSERT INTO Address(AddressId, Numero, Rue, CodePostal) VALUES(6, 21,'rue de la voie', 'F4H4S5');
SET IDENTITY_INSERT Address OFF

SET IDENTITY_INSERT Supplier ON
INSERT INTO Supplier(SupplierId, Nom, AddressId, Telephone) VALUES(1,'Johnson',1,'555-555-1111');
INSERT INTO Supplier(SupplierId, Nom, AddressId, Telephone) VALUES(2,'Bellus',2, '555-555-2222');
INSERT INTO Supplier(SupplierId, Nom, AddressId, Telephone) VALUES(3,'Corealis',3,'555-555-3333');
SET IDENTITY_INSERT Supplier OFF

SET IDENTITY_INSERT Product ON
INSERT INTO Product(ProductId, Nom, PrixUnitaire, QuantiteStock, Description, Marque, Categorie, SupplierId) VALUES(1, 'product1', 3.33, 11,'med1', 'Johnson', 'pharma', 1);
INSERT INTO Product(ProductId, Nom, PrixUnitaire, QuantiteStock, Description, Marque, Categorie, SupplierId) VALUES(2, 'product2', 6.66, 22,'med2', 'Bellus', 'pharma', 2);
INSERT INTO Product(ProductId, Nom, PrixUnitaire, QuantiteStock, Description, Marque, Categorie, SupplierId) VALUES(3, 'product3', 9.99, 33,'med3', 'Corealis', 'pharma', 3);
SET IDENTITY_INSERT Product OFF

SET IDENTITY_INSERT Customer ON
INSERT INTO Customer(CustomerId, Nom, Prenom, Telephone, AddressId, CredentialsId) VALUES(1, 'Cadet', 'Edward', '222-222-2222', 4, 1);
INSERT INTO Customer(CustomerId, Nom, Prenom, Telephone, AddressId, CredentialsId) VALUES(2, 'Tardif', 'Dominic', '555-555-5555', 5, 2);
SET IDENTITY_INSERT Customer OFF






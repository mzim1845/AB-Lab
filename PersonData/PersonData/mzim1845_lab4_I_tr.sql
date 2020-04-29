DECLARE @dbname nvarchar(128)
SET @dbname = N'Sajat'

IF (NOT EXISTS (SELECT name 
			FROM master.dbo.sysdatabases 
			WHERE ('[' + name + ']' = @dbname 
			OR name = @dbname)))
	CREATE DATABASE Sajat 
GO

USE Sajat;  
GO  


ALTER TABLE Vevok DROP CONSTRAINT SzemelyiSzam_FKV
ALTER TABLE Muveszek DROP CONSTRAINT SzemelyiSzam_FKM
ALTER TABLE Muveszek DROP CONSTRAINT StilusID_FKM
ALTER TABLE MuveszStilusok DROP CONSTRAINT StilusID_FKMS
ALTER TABLE MuveszStilusok DROP CONSTRAINT MuveszID_FKMS
ALTER TABLE Mualkotasok DROP CONSTRAINT MufajID_FK
ALTER TABLE Mualkotasok DROP CONSTRAINT MuveszID_FKM
ALTER TABLE AlkotasokKiallitason DROP CONSTRAINT KiallitasID_FK
ALTER TABLE AlkotasokKiallitason DROP CONSTRAINT MualkotasID_FKA
ALTER TABLE Szemelyek DROP CONSTRAINT OrszagID_FK

DROP TABLE IF EXISTS Vevok
DROP TABLE IF EXISTS Stilusiranyzatok
DROP TABLE IF EXISTS Szemelyek
DROP TABLE IF EXISTS MuveszStilusok
DROP TABLE IF EXISTS Mufajok
DROP TABLE IF EXISTS Kiallitasok
DROP TABLE IF EXISTS Mualkotasok
DROP TABLE IF EXISTS AlkotasokKiallitason
DROP TABLE IF EXISTS Orszagok
DROP TABLE IF EXISTS Muveszek

CREATE TABLE  Orszagok(
	OrszagID INT IDENTITY,
	OrszagNev VARCHAR(50),
    CONSTRAINT OrszagID_PK PRIMARY KEY(OrszagID)
);

CREATE TABLE  Szemelyek(
	SzemelyiSzam VARCHAR(13),
	SzemelyNev VARCHAR(50),
	Telszam	VARCHAR(12),
	OrszagID INT,
	CONSTRAINT SzemelyiSzam_PK PRIMARY KEY(SzemelyiSzam),
	CONSTRAINT OrszagID_FK FOREIGN KEY (OrszagID) REFERENCES Orszagok(OrszagID)
);



CREATE TABLE  Vevok(
	VevoID INT IDENTITY,
	SzemelyiSzam VARCHAR(13),
	CONSTRAINT VevoID_PK PRIMARY KEY(VevoID),
	CONSTRAINT SzemelyiSzam_FKV FOREIGN KEY (SzemelyiSzam) REFERENCES Szemelyek(SzemelyiSzam)
);


CREATE TABLE  Stilusiranyzatok(
	StilusID INT IDENTITY,
	StilusNev VARCHAR(50),
	CONSTRAINT StilusID_PK PRIMARY KEY(StilusID)
);


CREATE TABLE  Muveszek(
	MuveszID INT IDENTITY,
	Szuletes_idopontja DATE,
    Elhalalozas_idopontja DATE,
	SzemelyiSzam VARCHAR(13),
	StilusID INT,
	CONSTRAINT MuveszID_PK PRIMARY KEY(MuveszID),
	CONSTRAINT StilusID_FKM FOREIGN KEY (StilusID) REFERENCES Stilusiranyzatok(StilusID),
    CONSTRAINT SzemelyiSzam_FKM FOREIGN KEY (SzemelyiSzam) REFERENCES Szemelyek(SzemelyiSzam)
);


CREATE TABLE  MuveszStilusok(
    MuveszID INT,
	StilusID INT,
    CONSTRAINT MuveszID_FKMS FOREIGN KEY (MuveszID) REFERENCES Muveszek(MuveszID),
	CONSTRAINT StilusID_FKMS FOREIGN KEY (StilusID) REFERENCES Stilusiranyzatok(StilusID),
	PRIMARY KEY(MuveszID, StilusID)
);


CREATE TABLE  Mufajok(
	MufajID INT IDENTITY,
	MufajNev VARCHAR(50),
    CONSTRAINT MufajID_PK PRIMARY KEY(MufajID)
);


CREATE TABLE  Kiallitasok(
	KiallitasID INT IDENTITY,
	Cim VARCHAR(50),
	Megnyitoidopont DATE,
	CONSTRAINT KiallitasID_PK PRIMARY KEY(KiallitasID)
);


CREATE TABLE  Mualkotasok(
	MualkotasID INT IDENTITY,
	MualkotasCim VARCHAR(50),
	KeszitesEve INT,
	Ar Real,
	MuveszID INT,
	MufajID INT,
	CONSTRAINT MualkotasID_PK PRIMARY KEY(MualkotasID),
    CONSTRAINT MuveszID_FKM FOREIGN KEY (MuveszID) REFERENCES Muveszek(MuveszID),
	CONSTRAINT MufajID_FK FOREIGN KEY (MufajID) REFERENCES Mufajok(MufajID)

);


CREATE TABLE  AlkotasokKiallitason(
    MualkotasID INT,
	KiallitasID INT,
    CONSTRAINT MualkotasID_FKA FOREIGN KEY (MualkotasID) REFERENCES Mualkotasok(MualkotasID),
	CONSTRAINT KiallitasID_FK FOREIGN KEY (KiallitasID) REFERENCES Kiallitasok(KiallitasID),
	PRIMARY KEY(MualkotasID, KiallitasID)
);


INSERT INTO Orszagok(OrszagNev) VALUES('Libanon')
INSERT INTO Orszagok(OrszagNev) VALUES('Egyesult Kiralysag')
INSERT INTO Orszagok(OrszagNev) VALUES('Kanada')
INSERT INTO Orszagok(OrszagNev) VALUES('Kina')
INSERT INTO Orszagok(OrszagNev) VALUES('Japan')


INSERT INTO Stilusiranyzatok(StilusNev) VALUES ('absztrakt')
INSERT INTO Stilusiranyzatok(StilusNev) VALUES ('minimalizmus')
INSERT INTO Stilusiranyzatok(StilusNev) VALUES ('ujklasszicizmus')

INSERT INTO Kiallitasok(Cim, Megnyitoidopont) VALUES('Remains to be seen', '2019-08-15')
INSERT INTO Kiallitasok(Cim, Megnyitoidopont) VALUES('Dreamers Awake', '2018-12-10')

INSERT INTO Mufajok(MufajNev) VALUES('szobor')
INSERT INTO Mufajok(MufajNev) VALUES('festmeny')
INSERT INTO Mufajok(MufajNev) VALUES('installacio')

INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('2990123876391', 3, 'David Altmejd', '0492920283')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('1863844172389', 2, 'Rachel Kneebone', '040938117345')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('1782893182000', 2, 'Sarah Morris', '078312019')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('1028882154222', 1,'Mona Hatoum', '02928999301')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('1239387374732', 4, 'Kim Camachu', '019293008231')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('2937361872001', 2,'Janine Hall', '0145458231')
INSERT INTO Szemelyek(SzemelyiSzam, OrszagID, SzemelyNev, Telszam) VALUES('2828276632992', 5,'Liu Chafu', '04487012911')

INSERT INTO Muveszek(SzemelyiSzam, Szuletes_idopontja, StilusID) VALUES('2990123876391', '1974-06-24', 1)
INSERT INTO Muveszek(SzemelyiSzam, Szuletes_idopontja, Elhalalozas_idopontja, StilusID) VALUES('1782893182000', '1968-03-15', '2019-01-17', 3)
INSERT INTO Muveszek(SzemelyiSzam, Szuletes_idopontja, StilusID) VALUES('1863844172389', '2017-05-29', 3)
INSERT INTO Muveszek(SzemelyiSzam, Szuletes_idopontja, StilusID) VALUES('1028882154222', '1962-03-22', 2)

INSERT INTO Vevok(SzemelyiSzam) VALUES('1239387374732')
INSERT INTO Vevok(SzemelyiSzam) VALUES('2937361872001')
INSERT INTO Vevok(SzemelyiSzam) VALUES('2828276632992')


INSERT INTO Mualkotasok(MualkotasCim, KeszitesEve, Ar, MuveszID, MufajID) VALUES('Eye', 2015, 5500, 1, 1 )
INSERT INTO Mualkotasok(MualkotasCim, KeszitesEve, Ar, MuveszID, MufajID) VALUES('Centro de Formação', 2015, 10000.5, 3, 2)
INSERT INTO Mualkotasok(MualkotasCim, KeszitesEve, Ar, MuveszID, MufajID) VALUES('Total Eclipse', 2012, 12000, 3, 2)
INSERT INTO Mualkotasok(MualkotasCim, KeszitesEve, Ar, MuveszID, MufajID) VALUES('Map (mobile)', 2019, 17000.5, 4, 3)
INSERT INTO Mualkotasok(MualkotasCim, KeszitesEve, Ar, MuveszID, MufajID) VALUES('Still Life 2', 2015, 1325, 2, 1)

INSERT INTO AlkotasokKiallitason(MualkotasID, KiallitasID) VALUES(1, 1)
INSERT INTO AlkotasokKiallitason(MualkotasID, KiallitasID) VALUES(2, 1)
INSERT INTO AlkotasokKiallitason(MualkotasID, KiallitasID) VALUES(3, 1)
INSERT INTO AlkotasokKiallitason(MualkotasID, KiallitasID) VALUES(4, 2)
INSERT INTO AlkotasokKiallitason(MualkotasID, KiallitasID) VALUES(5, 1)



SELECT * FROM Orszagok
SELECT * FROM Szemelyek
SELECT * FROM Vevok
SELECT * FROM Muveszek
SELECT * FROM Stilusiranyzatok
SELECT * FROM MuveszStilusok
SELECT * FROM Mufajok
SELECT * FROM Mualkotasok
SELECT * FROM Kiallitasok
SELECT * FROM AlkotasokKiallitason


GO
CREATE OR ALTER TRIGGER Torles
ON Szemelyek
INSTEAD OF DELETE
AS BEGIN
    SET NOCOUNT ON
    DECLARE @szsz VARCHAR(15)=(SELECT Szemelyek.SzemelyiSzam FROM Szemelyek JOIN DELETED ON Szemelyek.Telszam=deleted.Telszam)
    IF(EXISTS(SELECT * FROM Vevok WHERE SzemelyiSzam=@szsz))
	BEGIN
		DELETE FROM Vevok
		WHERE SzemelyiSzam=@szsz
	END

	IF(EXISTS(SELECT * FROM Muveszek WHERE SzemelyiSzam=@szsz))
	BEGIN
	    DECLARE @mid INT = (SELECT MuveszID FROM Muveszek WHERE SzemelyiSzam=@szsz)

		DELETE a FROM AlkotasokKiallitason a
		INNER JOIN Mualkotasok m
		ON m.MualkotasID=a.MualkotasID
		WHERE MuveszID=@mid

		DELETE FROM Mualkotasok WHERE MuveszID=@mid

		DELETE FROM Muveszek
		WHERE SzemelyiSzam=@szsz

	END

	DELETE FROM Szemelyek WHERE SzemelyiSzam=@szsz

END
GO

DELETE FROM Szemelyek WHERE SzemelyNev='David Altmejd'

SELECT * FROM Vevok
SELECT * FROM Muveszek
SELECT * FROM Mualkotasok
SELECT * FROM Szemelyek



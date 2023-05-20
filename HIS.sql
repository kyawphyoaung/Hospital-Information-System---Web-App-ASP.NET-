USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='HospitalIS')
DROP DATABASE HospitalIS
GO

CREATE DATABASE HospitalIS
GO

--UserAccount--
USE HospitalIS
CREATE TABLE UserAccount(
	Username VARCHAR(30) NOT NULL,
	PWD VARCHAR(30) NOT NULL,
	CreateDate VARCHAR(11) NOT NULL,
	PRIMARY KEY (Username)
)
GO

--Patients--
USE HospitalIS
CREATE TABLE Patients(
	PatientID VARCHAR(10) NOT NULL,
	First_name VARCHAR(MAX) NOT NULL,
	Middle_name VARCHAR(MAX) NOT NULL,
	Last_name VARCHAR(MAX) NOT NULL,
	Gender CHAR(6) NOT NULL,
	DOB DATE NOT NULL,
	Age CHAR(3) NOT NULL,
	NRC VARCHAR(20) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	HomeNumber CHAR(4) NOT NULL,
	Street VARCHAR(25) NOT NULL,
	States VARCHAR(20) NOT NULL,
	Township VARCHAR(25) NOT NULL,
	Country VARCHAR(25) NOT NULL,
	PRIMARY KEY (PatientID)
)
GO

--ExternalPatient--
USE HospitalIS
CREATE TABLE ExternalPatient(
	PatientID VARCHAR(10) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NULL,
	Address VARCHAR(200) NULL,
	PRIMARY KEY (PatientID)
)
GO

--Generic--
USE HospitalIS
CREATE TABLE Generic(
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Active VARCHAR(50) NOT NULL,
	PRIMARY KEY (Code)
)
GO 

--Stores--
USE HospitalIS
CREATE TABLE Stores(
	Code VARCHAR(5) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Category VARCHAR(20) NOT NULL,
	PRIMARY KEY (Code)
)
GO

--Vendors--
USE HospitalIS
CREATE TABLE Vendors(
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(MAX) NOT NULL,
	PRIMARY KEY (Code)
)
GO

--Items--
USE HospitalIS
CREATE TABLE Items(
	Code VARCHAR(10) NOT NULL,
	Material VARCHAR(10) NULL,
	Name VARCHAR(100) NOT NULL,
	Active VARCHAR(50) NOT NULL,
	Generic VARCHAR(50) NOT NULL,
	Forms VARCHAR(20) NOT NULL,
	Route VARCHAR(15) NOT NULL,
	Strength VARCHAR(20) NOT NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NOT NULL,
	ReorderLevel VARCHAR(10) NOT NULL,
	PRIMARY KEY (Code)
)
GO

--IssueOnDemand--
USE HospitalIS
CREATE TABLE IssueOnDemand(
	PatientID VARCHAR(10) NOT NULL,
	IssueNumber VARCHAR(10) NOT NULL,
	IssueStatus VARCHAR(10) NOT NULL,
	Store VARCHAR(50) NOT NULL,
	IssuedDate DATE NOT NULL,
	PRIMARY KEY (IssueNumber),
	FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
)
GO

--SaleReportDraft--
USE HospitalIS
CREATE TABLE SaleReportDraft(
	PatientID VARCHAR(10) NOT NULL,
	IssueNumber VARCHAR(10) NOT NULL,
	IssueStatus VARCHAR(10) NOT NULL,
	Store VARCHAR(50) NOT NULL,
	IssuedDate DATE NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(100)  NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	Quantity INT NULL,
	Differ INT NULL
)
GO

--SaleReport--
USE HospitalIS
CREATE TABLE SaleReport(
	PatientID VARCHAR(10) NOT NULL,
	IssueNumber VARCHAR(10) NOT NULL,
	IssueStatus VARCHAR(10) NOT NULL,
	Store VARCHAR(50) NOT NULL,
	IssuedDate DATE NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(100)  NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	Quantity INT NULL,
	Differ INT NULL
)
GO

--AddItems--
USE HospitalIS
CREATE TABLE AddItems(
	PatientID VARCHAR(10) NULL,
	IssueNumber VARCHAR(10) NOT NULL,
	IssueStatus VARCHAR(10) NOT NULL,
	Store VARCHAR(50) NOT NULL,
	ReceiptStore VARCHAR(50) NULL,
	IssuedDate DATE NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(100)  NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	Quantity INT NULL,
	Differ INT NULL
)
GO

--GoodReceiptNotes--
USE HospitalIS
CREATE TABLE GoodReceiptNotes(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Store VARCHAR(50) NOT NULL,
	Status VARCHAR(10) NOT NULL,
	PRIMARY KEY (DocumentNumber)
)
GO

--MedicalStore--
USE HospitalIS
CREATE TABLE MedicalStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--Pharmacy--
USE HospitalIS
CREATE TABLE Pharmacy(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--EmergencyCrashkart--
USE HospitalIS
CREATE TABLE EmergencyCrashkart(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--LaboratoryStore--
USE HospitalIS
CREATE TABLE LaboratoryStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--TransitStore--
USE HospitalIS
CREATE TABLE TransitStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--ConsignmentStore--
USE HospitalIS
CREATE TABLE ConsignmentStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--CSSDStore--
USE HospitalIS
CREATE TABLE CSSDStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--GeneralStore--
USE HospitalIS
CREATE TABLE GeneralStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--InterTransitStore--
USE HospitalIS
CREATE TABLE InterTransitStore(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--IPPharmacy--
USE HospitalIS
CREATE TABLE IPPharmacy(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--TransactionStock--
USE HospitalIS
CREATE TABLE TransactionStock(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	IssueStore VARCHAR(50) NOT NULL,
	ReceiptStore VARCHAR(50) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	Status VARCHAR(10) NOT NULL,
	PRIMARY KEY (DocumentNumber)
)
GO

--StockLedger--
USE HospitalIS
CREATE TABLE StockLedger(
	Store VARCHAR(50) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	TransactionType VARCHAR(10) NOT NULL,
	RefDocNo VARCHAR(10) NOT NULL,
	RefDocDate DATE NOT NULL,
	StockInQty INT NULL,
	StockOutQty INT NULL,
	ClosingStock INT NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
)
GO

--StockLedgerDraft--
USE HospitalIS
CREATE TABLE StockLedgerDraft(
	Store VARCHAR(50) NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	TransactionType VARCHAR(10) NULL,
	RefDocNo VARCHAR(10) NOT NULL,
	RefDocDate DATE NOT NULL,
	StockInQty INT NULL,
	StockOutQty INT NULL,
	ClosingStock INT NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL
)
GO

--MedicalStoreDraft--
USE HospitalIS
CREATE TABLE MedicalStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--PharmacyDraft--
USE HospitalIS
CREATE TABLE PharmacyDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--EmergencyCrashkartDraft--
USE HospitalIS
CREATE TABLE EmergencyCrashkartDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--LaboratoryStoreDraft--
USE HospitalIS
CREATE TABLE LaboratoryStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--TransitStoreDraft--
USE HospitalIS
CREATE TABLE TransitStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--ConsignmentStoreDraft--
USE HospitalIS
CREATE TABLE ConsignmentStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--CSSDStoreDraft--
USE HospitalIS
CREATE TABLE CSSDStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--GeneralStoreDraft--
USE HospitalIS
CREATE TABLE GeneralStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--InterTransitStoreDraft--
USE HospitalIS
CREATE TABLE InterTransitStoreDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO

--IPPharmacyDraft--
USE HospitalIS
CREATE TABLE IPPharmacyDraft(
	DocumentNumber VARCHAR(10) NOT NULL,
	DocumentDate DATE NOT NULL,
	Vendor VARCHAR(150) NOT NULL,
	Code VARCHAR(10) NULL,
	Name VARCHAR(100) NULL,
	Generic VARCHAR(50) NULL,
	Batch VARCHAR(20) NULL,
	Expiry DATE NULL,
	Stock INT NULL,
	FOREIGN KEY (Code) REFERENCES Items(Code)
)
GO
----------------------------------------------
--Trigger trg_calculate_differ
CREATE TRIGGER trg_calculate_differ
ON AddItems
AFTER UPDATE
AS
	DECLARE @issueNumber VARCHAR(10)
	DECLARE @number VARCHAR(10)

	SET @number = (SELECT IssueNumber FROM INSERTED)
	SET @issueNumber = SUBSTRING(@number,1,3)

	DECLARE @store VARCHAR(50)
	SET @store = (SELECT Store FROM INSERTED)

	DECLARE @receiptStore VARCHAR(50)
	SET @receiptStore = (SELECT ReceiptStore FROM INSERTED)
	
	DECLARE @Code VARCHAR(10)
	SET @Code = (SELECT Code FROM INSERTED)
	DECLARE @Stock int
	SET @Stock = (SELECT Stock FROM INSERTED)
	DECLARE @Quantity int
	SET @Quantity = (SELECT Quantity FROM INSERTED)

	IF(@issueNumber='OTC')
	BEGIN
		UPDATE AddItems
		SET Differ = @Stock - @Quantity
		WHERE Code = @Code

		UPDATE SaleReportDraft
		SET Quantity = @Quantity, Differ = (@Stock - @Quantity)
		WHERE Code = @Code

		UPDATE StockLedgerDraft
		SET StockOutQty = @Quantity, ClosingStock = (@Stock - @Quantity)
		WHERE Code = @Code
	END
	
	IF(@issueNumber='GRN')
	BEGIN
		UPDATE AddItems
		SET Differ = @Stock + @Quantity
		WHERE Code = @Code

		UPDATE StockLedgerDraft
		SET StockINQty = @Quantity, ClosingStock = (@Stock + @Quantity)
		WHERE Code = @Code

		IF(@store = 'Medical Store')
		BEGIN
			UPDATE MedicalStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'Pharmacy')
		BEGIN
			UPDATE PharmacyDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'Emergency Crashkart')
		BEGIN
			UPDATE EmergencyCrashkartDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'Laboratory Store')
		BEGIN
			UPDATE LaboratoryStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'Transit Store')
		BEGIN
			UPDATE TransitStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'Consignment Store')
		BEGIN
			UPDATE ConsignmentStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'CSSD Store')
		BEGIN
			UPDATE CSSDStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'General Store')
		BEGIN
			UPDATE GeneralStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'InterTransit Store')
		BEGIN
			UPDATE InterTransitStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
		IF(@store = 'IP Pharmacy')
		BEGIN
			UPDATE IPPharmacyDraft
			SET Stock = @Quantity
			WHERE Code = @Code
		END
	END

	IF(@issueNumber='SRC')
	BEGIN	
		UPDATE AddItems
		SET Differ = @Stock - @Quantity
		WHERE Code = @Code

		IF(@receiptStore = 'Medical Store')
		BEGIN
			UPDATE MedicalStoreDraft
			SET Stock = @Quantity
			WHERE Code = @Code

			UPDATE StockLedgerDraft
			SET StockInQty = @Quantity
			WHERE Code = @Code AND Store = @receiptStore
		END
		IF(@receiptStore = 'Pharmacy')
		BEGIN
			UPDATE PharmacyDraft
			SET Stock = @Quantity
			WHERE Code = @Code

			UPDATE StockLedgerDraft
			SET StockInQty = @Quantity
			WHERE Code = @Code AND Store = @receiptStore
		END
		IF(@store = 'Medical Store')
		BEGIN
			UPDATE StockLedgerDraft
			SET StockOutQty = @Quantity
			WHERE Code = @code AND Store = @store
		END
		IF(@store = 'Pharmacy')
		BEGIN
			UPDATE StockLedgerDraft
			SET StockOutQty = @Quantity
			WHERE Code = @code AND Store = @store
		END
	END
----------------------------------------------------------------
SELECT * FROM Generic

SELECT * FROM Stores

SELECT * FROM Vendors

SELECT * FROM Items

SELECT * FROM Patients

SELECT * FROM ExternalPatient

SELECT * FROM IssueOnDemand

SELECT * FROM AddItems

SELECT * FROM SaleReport

SELECT * FROM GoodReceiptNotes

SELECT * FROM MedicalStore

SELECT * FROM Pharmacy

SELECT * FROM EmergencyCrashkart

SELECT * FROM LaboratoryStore

SELECT * FROM TransitStore

SELECT * FROM ConsignmentStore

SELECT * FROM CSSDStore

SELECT * FROM GeneralStore

SELECT * FROM InterTransitStore

SELECT * FROM IPPharmacy

SELECT * FROM TransactionStock

SELECT * FROM StockLedger

SELECT * FROM StockLedgerDraft

SELECT * FROM AddItems

SELECT * FROM SaleReport

SELECT * FROM MedicalStoreDraft

SELECT * FROM PharmacyDraft

SELECT * FROM EmergencyCrashkartDraft

SELECT * FROM LaboratoryStoreDraft

SELECT * FROM TransitStoreDraft

SELECT * FROM ConsignmentStoreDraft

SELECT * FROM CSSDStoreDraft

SELECT * FROM GeneralStoreDraft

SELECT * FROM InterTransitStoreDraft

SELECT * FROM IPPharmacyDraft

SELECT * FROM AddItems

SELECT * FROM StockLedgerDraft

SELECT * FROM MedicalStoreDraft
-------------------------------------	
INSERT UserAccount VALUES('admin','1234',GETDATE())

select * from Patients

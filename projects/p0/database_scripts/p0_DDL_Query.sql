--Before doing anything, use master
USE master;
go

--Drop database
DROP TABLE Store.OrderProduct;
DROP TABLE Store.StoreOrder;
DROP TABLE Store.StoreInventory;
DROP TABLE Store.Product;
DROP TABLE Store.Store;
DROP TABLE Customer.Customer;
--go

--Create database
CREATE DATABASE StoreApplicationDB;
go

--Use the database after creating it to interact with it.
USE StoreApplicationDB;
go

CREATE SCHEMA Store;
go

CREATE SCHEMA Customer;
go

CREATE TABLE Customer.Customer
(
	CustomerId SMALLINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100) NOT NULL,
	ACTIVE BIT NOT NULL,
);

CREATE TABLE Store.Store
(
	StoreId SMALLINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100) NOT NULL,
	City VARCHAR (100),
	[State] CHAR(2),
	ACTIVE BIT NOT NULL,
);

CREATE TABLE Store.Product
(
	ProductId SMALLINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255),
	Price MONEY NOT NULL,
	ACTIVE BIT NOT NULL,
);

CREATE TABLE Store.StoreOrder
(
	OrderId SMALLINT PRIMARY KEY IDENTITY(1,1),
	CustomerId SMALLINT NOT NULL,
	StoreId SMALLINT NOT NULL,
	OrderDate DATETIME2 NOT NULL,
	ACTIVE BIT NOT NULL,
);

CREATE TABLE Store.OrderProduct
(
	OrderId SMALLINT NOT NULL,
	ProductId SMALLINT NOT NULL,
	ACTIVE BIT NOT NULL
);

CREATE TABLE Store.StoreInventory
(
	StoreId SMALLINT NOT NULL,
	ProductId SMALLINT NOT NULL,
	ACTIVE BIT NOT NULL
);
GO

--Alter Table
--StoreOrder
ALTER TABLE Store.StoreOrder
ADD CONSTRAINT FK_ORDER_CUSTOMER FOREIGN KEY (CustomerId) REFERENCES Customer.Customer(CustomerId);

ALTER  TABLE Store.StoreOrder
ADD CONSTRAINT FK_ORDER_STORE FOREIGN KEY (StoreId) REFERENCES Store.Store(StoreId);

--OrderProduct
ALTER TABLE Store.OrderProduct
ADD CONSTRAINT FK_ORDER_ORDER FOREIGN KEY (OrderId) REFERENCES Store.StoreOrder(OrderId);

ALTER TABLE Store.OrderProduct
ADD CONSTRAINT FK_ORDER_PRODUCT FOREIGN KEY (ProductId) REFERENCES Store.Product(ProductId);

--StoreInventory
ALTER TABLE Store.StoreInventory
ADD CONSTRAINT FK_INVENTORY_STORE FOREIGN KEY (StoreId) REFERENCES Store.Store(StoreId);

ALTER TABLE Store.StoreInventory
ADD CONSTRAINT FK_INVENTORY_PRODUCT FOREIGN KEY (ProductId) REFERENCES Store.Product(ProductId);

--Default Active
ALTER TABLE Customer.Customer
ADD CONSTRAINT DF_Customer default (1) for Active;

ALTER TABLE Store.Store
ADD CONSTRAINT DF_Store default (1) for Active;

ALTER TABLE Store.StoreOrder
ADD CONSTRAINT DF_Order default (1) for Active;

ALTER TABLE Store.OrderProduct
ADD CONSTRAINT DF_OrderProduct default (1) for Active;

ALTER TABLE Store.Product
ADD CONSTRAINT DF_Product default (1) for Active;

ALTER TABLE Store.StoreInventory
ADD CONSTRAINT DF_Inventory default (1) for Active;

--Date Constraint
ALTER TABLE Store.StoreOrder
ADD CONSTRAINT CK_Order CHECK (ORDERDATE >= GETDATE());
GO

--Stored Procedure
CREATE OR ALTER PROCEDURE SP_AddCustomer(@NAME varchar(100))
AS
BEGIN
	DECLARE @matchname VARCHAR(100);

	SELECT @matchname = [name]
	FROM Customer.Customer
	WHERE [name] = @NAME;

	IF(@matchname IS NULL)
	BEGIN
		INSERT INTO Customer.Customer([name])
		VALUES (@NAME)
	END
END

EXEC SP_AddCustomer 'Fred';
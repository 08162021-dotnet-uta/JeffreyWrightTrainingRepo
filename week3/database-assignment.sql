CREATE DATABASE Demo_08162021batch;

USE Demo_08162021batch;
GO

--create an insert statement for one product
CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
ProductName varchar(50) NOT NULL,
ProductDescription varchar(100) NOT NULL,
ProductPrice decimal(19,2) NOT NULL);

--create an insert statement for one customer
CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL);

-- be ready to create an order with at least
CREATE TABLE ItemizedOrders(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
OrderId uniqueidentifier NOT NULL DEFAULT newid(),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
OrderDate date NOT NULL,
totalAmount decimal(19,2) NOT NULL);

-- I will create a view to display any particular order and it's details.

-- Create a customer
INSERT INTO Customers
VALUES ('Jeffrey', 'Wright');

-- Create 3 products
INSERT INTO Products
VALUES ('Lays Chips (3oz)', 'Potato chips in a bag', 1.99);

INSERT INTO ItemizedOrders (orderid, customerid, productid, orderdate, totalAmount)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 8, 20, GETDATE());
INSERT INTO ItemizedOrders (orderid, customerid, productid, orderdate, totalAmount)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 8, 6, GETDATE());
INSERT INTO ItemizedOrders (orderid, customerid, productid, orderdate, totalAmount)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 8, 21, GETDATE());
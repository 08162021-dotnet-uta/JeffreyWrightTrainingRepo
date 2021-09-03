CREATE DATABASE Demo_08162021batch;

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
OrderDate date NOT NULL,
totalAmount decimal(19,2) NOT NULL);

CREATE TABLE OrderProducts(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
OrderId uniqueidentifier NOT NULL FOREIGN KEY REFERENCES ItemizedOrders(ItemizedId),
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
);

-- I will create a view to display any particular order and it's details.
DROP TABLE ItemizedOrders;

-- Create a customer
INSERT INTO Customers
VALUES ('Jeffrey', 'Wright');

-- Create 3 products
INSERT INTO Products
VALUES ('Lays Chips (3oz)', 'Potato chips in a bag', 1.99), ('Foster Farms Chicken Nuggets (Family Pack)', 'A bag of chicken nuggets. Perfect for young families.', 11.99), ('Mug Root Beer (1 L)', 'A 1 Liter Bottle of Root Beer', 2.99);

SELECT * FROM PRODUCTS;

INSERT INTO ItemizedOrders
VALUES(1, 1, 2, 3, GETDATE(), (SELECT ProductPrice FROM Products WHERE PRODUCTID = 1));
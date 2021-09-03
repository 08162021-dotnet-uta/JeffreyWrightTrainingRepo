USE StoreApplicationDB;
GO

SELECT *
FROM Customer.Customer;

SELECT *
FROM Store.StoreOrder;

SELECT *
FROM Store.Store;

INSERT INTO Customer.Customer ([Name])
VALUES ('Jeffrey Wright'), ('Michael Wright'), ('Catherine Wright');

INSERT INTO Customer.Customer ([Name])
VALUES ('Kyle Hill');

INSERT INTO Customer.Customer ([Name])
VALUES ('Ultimate Man');

INSERT INTO Store.Store (STORENAME, STORECITY, STORESTATE)
VALUES ('Best Buy', 'Lafayette', 'IN'), ('IKEA', 'Fishers', 'IN'), ('FYE', 'Lafayette', 'IN');

INSERT INTO Store.Product (PRODUCTNAME, PRICE)
VALUES ('Smartphone', 700), ('Phone Charger', 19.99), ('Laptop', 900), ('Table', 250), ('Office Chair', 200), ('Bed /w Mattress', 2500);

SELECT CUSTOMERNAME
FROM Store.Product as sp
INNER JOIN Store.OrderProduct AS sop ON sp.PRODUCTID = sop.PRODUCTID
LEFT JOIN Store.StoreOrder AS so ON so.ORDERID = sop.ORDERID --Left join purpose: All store prouct records have an order id.
LEFT JOIN Customer.Customer AS cu ON cu.CUSTOMERID = so.CUSTOMERID --Left join purpose: All store order records have a customer id.
WHERE PRODUCTNAME = 'Smartphone';

SELECT [Name]
FROM Customer.Customer;
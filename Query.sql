/* Создаем таблицы */

CREATE TABLE Categories(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL
);

CREATE TABLE Products(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	CategoryId INT
);

/* Наполняем данными */ 

INSERT INTO Categories (Name) VALUES ('Products'), ('Alcohol')

INSERT INTO Products (Name, CategoryId) VALUES ('Milk', 1), ('Wine', 2)
INSERT INTO Products (Name) VALUES ('Tape')

/* Делаем запрос */

SELECT Products.Name Product,
         Categories.Name Category
FROM Products
LEFT JOIN Categories
    ON Categories.Id = Products.CategoryId

/*

Результат запроса:

+---+---------+----------+
|   | Product | Category |
+---+---------+----------+
| 1 | Milk    | Products |
| 2 | Wine    | Alcohol  |
| 3 | Tape    | NULL     |
+---+---------+----------+

*/
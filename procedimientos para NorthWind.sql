/*PROCEDIMIENTOS ALMACENADOS*/
/*BASICOS*/
USE Northwind
GO
-- 1. LISTAR TODOS LOS CLIENTES
CREATE OR ALTER PROC spNW_ListarClientes
AS
BEGIN
    SELECT * FROM Customers
END
GO

-- PRUEBA
EXEC spNW_ListarClientes
GO

-- 2. BUSCAR PRODUCTO POR ID

CREATE OR ALTER PROC spNW_BuscarProductoPorID
    @ProductID INT
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE ProductID = @ProductID
END
GO

-- PRUEBA
EXEC spNW_BuscarProductoPorID 1
GO

-- 3. PRODUCTOS CON STOCK MAYOR A X

CREATE OR ALTER PROC spNW_ProductosStockMayor
    @Stock INT
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE UnitsInStock > @Stock
END
GO

-- PRUEBA
EXEC spNW_ProductosStockMayor 10
GO


-- 4. CLIENTES POR PAÍS
CREATE OR ALTER PROC spNW_ClientesPorPais
    @Country VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Customers
    WHERE Country = @Country
END
GO

-- PRUEBA
EXEC spNW_ClientesPorPais 'USA'
GO

/*                                              Intermedios*/

USE Northwind
GO

-- total de pedidos por cliente
CREATE OR ALTER PROC spNW_TotalPedidosPorCliente
AS
BEGIN
    SELECT 
        c.CustomerID,
        c.CompanyName,
        COUNT(o.OrderID) AS TotalPedidos
    FROM Customers c
    INNER JOIN Orders o ON c.CustomerID = o.CustomerID
    GROUP BY c.CustomerID, c.CompanyName
    ORDER BY TotalPedidos DESC
END
GO


-- pedidos entre fechas
CREATE OR ALTER PROC spNW_PedidosEntreFechas
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT 
        o.OrderID,
        c.CompanyName,
        o.OrderDate,
        o.ShippedDate,
        o.Freight
    FROM Orders o
    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
    WHERE o.OrderDate BETWEEN @FechaInicio AND @FechaFin
    ORDER BY o.OrderDate
END
GO


-- productos con categoria y proveedor
CREATE OR ALTER PROC spNW_ProductosCategoriaProveedor
AS
BEGIN
    SELECT 
        p.ProductID,
        p.ProductName,
        c.CategoryName,
        s.CompanyName AS Proveedor,
        p.UnitPrice,
        p.UnitsInStock
    FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
    INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
    ORDER BY c.CategoryName, p.ProductName
END
GO

EXEC spNW_TotalPedidosPorCliente
EXEC spNW_PedidosEntreFechas '1996-07-01','1997-01-01'
EXEC spNW_ProductosCategoriaProveedor



/*                                      avanzados                      */

USE Northwind
GO

-- pedidos entre fechas con total mayor al promedio
CREATE OR ALTER PROC spNW_PedidosEntreFechasMayorPromedio
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT 
        o.OrderID,
        o.CustomerID,
        o.OrderDate,
        SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalPedido
    FROM Orders o
    INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.OrderDate BETWEEN @FechaInicio AND @FechaFin
    GROUP BY o.OrderID, o.CustomerID, o.OrderDate
    HAVING SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) >
    (
        SELECT AVG(Total)
        FROM
        (
            SELECT SUM(od2.UnitPrice * od2.Quantity * (1 - od2.Discount)) AS Total
            FROM [Order Details] od2
            GROUP BY od2.OrderID
        ) AS Promedios
    )
END
GO

EXEC spNW_PedidosEntreFechasMayorPromedio '1996-07-01', '1997-01-01'
GO


-- clientes de un pais con compras mayores al promedio
CREATE OR ALTER PROC spNW_ClientesPaisMayorPromedio
    @Pais NVARCHAR(50)
AS
BEGIN
    SELECT 
        c.CustomerID,
        c.CompanyName,
        c.Country,
        SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalComprado
    FROM Customers c
    INNER JOIN Orders o ON c.CustomerID = o.CustomerID
    INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE c.Country = @Pais
    GROUP BY c.CustomerID, c.CompanyName, c.Country
    HAVING SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) >
    (
        SELECT AVG(TotalCliente)
        FROM
        (
            SELECT SUM(od2.UnitPrice * od2.Quantity * (1 - od2.Discount)) AS TotalCliente
            FROM Customers c2
            INNER JOIN Orders o2 ON c2.CustomerID = o2.CustomerID
            INNER JOIN [Order Details] od2 ON o2.OrderID = od2.OrderID
            GROUP BY c2.CustomerID
        ) AS Promedios
    )
END
GO

EXEC spNW_ClientesPaisMayorPromedio 'USA'
GO


-- productos nunca vendidos
CREATE OR ALTER PROC spNW_ProductosNuncaVendidos
AS
BEGIN
    SELECT 
        p.ProductID,
        p.ProductName,
        p.UnitPrice,
        p.UnitsInStock
    FROM Products p
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM [Order Details] od
        WHERE od.ProductID = p.ProductID
    )
END
GO

EXEC spNW_ProductosNuncaVendidos
GO


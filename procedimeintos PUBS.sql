USE pubs
GO
-- 1. LISTAR AUTORES

select * from authors;
go 

CREATE OR ALTER PROC spPubs_ListarAutores
AS
BEGIN
    SELECT * FROM authors
END
GO

-- 2. BUSCAR TÍTULO POR ID
CREATE OR ALTER PROC spPubs_BuscarTituloPorID
    @title_id VARCHAR(6)
AS
BEGIN
    SELECT * 
    FROM titles
    WHERE title_id = @title_id
END
GO

-- 3. TÍTULOS CON PRECIO MAYOR

CREATE OR ALTER PROC spPubs_TitulosPrecioMayor
    @price MONEY
AS
BEGIN
    SELECT * 
    FROM titles
    WHERE price > @price
END
GO

-- 4. EDITORIALES POR PAÍS

CREATE OR ALTER PROC spPubs_EditorialesPorPais
    @country VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM publishers
    WHERE country = @country
END
GO

EXEC spPubs_ListarAutores
EXEC spPubs_BuscarTituloPorID 'BU1032'
EXEC spPubs_TitulosPrecioMayor 10
EXEC spPubs_EditorialesPorPais 'USA'




/*                                      INTERMEDIOS                     */ 
USE pubs
GO

-- cantidad de libros por editorial
CREATE OR ALTER PROC spPubs_CantidadTitulosPorEditorial
AS
BEGIN
    SELECT 
        p.pub_id,
        p.pub_name,
        COUNT(t.title_id) AS TotalTitulos
    FROM publishers p
    INNER JOIN titles t ON p.pub_id = t.pub_id
    GROUP BY p.pub_id, p.pub_name
    ORDER BY TotalTitulos DESC
END
GO

EXEC spPubs_CantidadTitulosPorEditorial
GO


-- autores con sus libros
CREATE OR ALTER PROC spPubs_AutoresConTitulos
AS
BEGIN
    SELECT 
        a.au_id,
        a.au_fname + ' ' + a.au_lname AS Autor,
        t.title_id,
        t.title AS Titulo,
        t.type AS Tipo
    FROM authors a
    INNER JOIN titleauthor ta ON a.au_id = ta.au_id
    INNER JOIN titles t ON ta.title_id = t.title_id
    ORDER BY Autor
END
GO

EXEC spPubs_AutoresConTitulos
GO


-- ventas por titulo
CREATE OR ALTER PROC spPubs_VentasPorTitulo
AS
BEGIN
    SELECT 
        t.title_id,
        t.title AS Titulo,
        SUM(s.qty) AS TotalVendido
    FROM titles t
    INNER JOIN sales s ON t.title_id = s.title_id
    GROUP BY t.title_id, t.title
    ORDER BY TotalVendido DESC
END
GO

EXEC spPubs_VentasPorTitulo
GO


/*                   AVANZADOS                   */

USE pubs
GO

-- libros con ventas mayores al promedio
CREATE OR ALTER PROC spPB_TitulosMayorPromedioVentas
AS
BEGIN
    SELECT 
        t.title_id,
        t.title,
        SUM(s.qty) AS TotalVendido
    FROM titles t
    INNER JOIN sales s ON t.title_id = s.title_id
    GROUP BY t.title_id, t.title
    HAVING SUM(s.qty) >
    (
        SELECT AVG(total)
        FROM (
            SELECT SUM(qty) AS total
            FROM sales
            GROUP BY title_id
        ) AS Promedio
    )
END
GO

EXEC spPB_TitulosMayorPromedioVentas
GO


-- autores por estado con cantidad de libros mayor al promedio
CREATE OR ALTER PROC spPB_AutoresEstadoMayorPromedio
    @estado VARCHAR(2)
AS
BEGIN
    SELECT 
        a.au_id,
        a.au_fname + ' ' + a.au_lname AS Autor,
        COUNT(ta.title_id) AS CantidadLibros
    FROM authors a
    INNER JOIN titleauthor ta ON a.au_id = ta.au_id
    WHERE a.state = @estado
    GROUP BY a.au_id, a.au_fname, a.au_lname
    HAVING COUNT(ta.title_id) >
    (
        SELECT AVG(cantidad)
        FROM (
            SELECT COUNT(title_id) AS cantidad
            FROM titleauthor
            GROUP BY au_id
        ) AS Promedio
    )
END
GO

EXEC spPB_AutoresEstadoMayorPromedio 'CA'
GO


-- editoriales clasificadas por ventas
CREATE OR ALTER PROC spPB_EditorialesClasificadas
AS
BEGIN
    SELECT 
        p.pub_id,
        p.pub_name,
        SUM(s.qty) AS TotalVentas,
        CASE
            WHEN SUM(s.qty) >= 100 THEN 'ALTA'
            WHEN SUM(s.qty) >= 50 THEN 'MEDIA'
            ELSE 'BAJA'
        END AS NivelVentas
    FROM publishers p
    INNER JOIN titles t ON p.pub_id = t.pub_id
    INNER JOIN sales s ON t.title_id = s.title_id
    GROUP BY p.pub_id, p.pub_name
    ORDER BY TotalVentas DESC
END
GO

EXEC spPB_EditorialesClasificadas
GO


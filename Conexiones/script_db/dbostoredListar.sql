USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 15/4/2024 19:15:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[storedListar] as select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id 
from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id 
GO


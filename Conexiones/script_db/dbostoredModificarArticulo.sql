USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 15/4/2024 19:16:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[storedModificarArticulo]
@Codigo varchar(50),
@Nombre varchar (50),
@Descripcion varchar (300),
@IdMarca int,
@Idcategoria int,
@ImagenUrl varchar(500),
@Precio money,
@Id int as


update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca,
IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio  where Id = @Id
GO


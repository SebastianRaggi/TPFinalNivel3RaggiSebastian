USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedAltaArticulos]    Script Date: 15/4/2024 19:14:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[storedAltaArticulos]
@Codigo varchar,  
@Nombre varchar (50), 
@Descripcion varchar (100), 
@idMarca int, 
@idCategoria int, 
@ImagenUrl varchar (500), 
@Precio money as 
insert into ARTICULOS values (@Codigo , @Nombre , @Descripcion , @idMarca , @idCategoria , @ImagenUrl , @Precio)
GO


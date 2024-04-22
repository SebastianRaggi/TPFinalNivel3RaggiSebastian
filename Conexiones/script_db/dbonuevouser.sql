USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[nuevoUser]    Script Date: 15/4/2024 19:12:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE procedure [dbo].[nuevoUser]
 @email varchar (50),
 @pass varchar (20)
 as
insert into USERS(email, pass, admin) output inserted.Id values (@email, @pass, 0)

GO


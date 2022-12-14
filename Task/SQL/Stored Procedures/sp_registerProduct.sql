USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_registerProduct]    Script Date: 10/12/2022 11:19:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_registerProduct]
	@code nvarchar(50),
	@name nvarchar(50),
	@unitPrice money
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Products]
           ([Code]
           ,[Name]
           ,[UnitPrice])
     VALUES
           (@code,
			@name,
			@unitPrice)
END

USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_registerSale]    Script Date: 10/12/2022 11:19:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_registerSale]
	@distributorId int,
	@saleDate date,
	@productCode nvarchar(50),
	@productName nvarchar(50),
	@price money,
	@unitPrice money, 
	@totalPrice money
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Sales]
           ([DistributorID]
           ,[SaleDate]
           ,[ProductCode]
           ,[ProductName]
           ,[Price]
           ,[UnitPrice]
           ,[TotalPrice]
		   ,[IncludedInBonus])
     VALUES
           (@distributorId,
			@saleDate,
			@productCode,
			@productName,
			@price,
			@unitPrice,
			@totalPrice,
			0)

END

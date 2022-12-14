USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_getFilteredSales]    Script Date: 10/12/2022 11:18:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_getFilteredSales] 
	@distributorId int,
	@saleDate date, 
	@productCode nvarchar(50),
	@productName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Sales s
	WHERE s.DistributorID = @distributorId 
	AND s.SaleDate = @saleDate 
	AND s.ProductCode LIKE '%' + ISNULL(@productCode, '') + '%'
	AND s.ProductName LIKE '%' + ISNULL(@productName, '') + '%'
	

END

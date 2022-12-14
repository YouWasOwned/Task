USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_filterDistributors]    Script Date: 10/12/2022 11:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_filterDistributors]
	@name nvarchar(50),
	@surname nvarchar(50),
	@minBonusAmount money,
	@maxBonusAmount money
AS
BEGIN
	SET NOCOUNT ON;

	SELECT d.ID,
	   d.Name,
	   d.Surname,
	   b.BonusAmount
	FROM Bonuses b
	LEFT JOIN Distributors d ON d.ID = b.DistributorID
	WHERE b.BonusAmount >= @minBonusAmount AND b.BonusAmount <= @maxBonusAmount 
	AND d.Name LIKE '%' + @name + '%' AND d.Surname LIKE '%' + @surname + '%'
END

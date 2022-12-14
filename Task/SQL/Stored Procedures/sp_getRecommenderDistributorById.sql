USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_getRecommenderDistributorById]    Script Date: 10/12/2022 11:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_getRecommenderDistributorById] 
	@recommenderId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT d.ID, 
		d.Level,
		d.RecommendedDistributorsCount
	FROM Distributors d WHERE d.ID = @recommenderId
END

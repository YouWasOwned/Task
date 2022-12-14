USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateDistributorRecommendedDistributorsCount]    Script Date: 10/12/2022 11:20:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_updateDistributorRecommendedDistributorsCount]
	@distibutorId int, 
	@recommendedDistributorsCount int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Distributors SET RecommendedDistributorsCount = @recommendedDistributorsCount WHERE ID = @distibutorId
END

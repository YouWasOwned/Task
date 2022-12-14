USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDistributorBonuses]    Script Date: 10/12/2022 11:17:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_getDistributorBonuses]
	@endDate datetime2,
	@startDate datetime2
AS
BEGIN
	BEGIN TRY

	BEGIN TRANSACTION
		SET NOCOUNT ON;

		--Lvl1 distributor bonuses
		SELECT DISTINCT d.ID,
		SUM(s.TotalPrice * 0.1) OVER (PARTITION BY d.ID ORDER BY d.ID) as [BonusAmount]
		INTO #Lvl1Distributors
		FROM Distributors d
		LEFT JOIN Sales s ON s.DistributorID = d.ID
		WHERE s.SaleDate BETWEEN @startDate AND @endDate AND s.IncludedInBonus = 0

		--Lvl2 distributor bonuses
		SELECT lvl1.ID [Lvl1DistributorID],
		d.ID [Lvl2DistributorID],
		SUM(s.TotalPrice * 0.05) OVER (PARTITION BY d.ID ORDER BY d.ID) as [BonusAmount]
		INTO #Lvl2Distributors 
		FROM #Lvl1Distributors lvl1
		LEFT JOIN Distributors d ON lvl1.ID = d.RecommenderID
		LEFT JOIN Sales s ON s.DistributorID = d.ID
		WHERE s.SaleDate BETWEEN @startDate AND @endDate AND s.IncludedInBonus = 0

		--Lvl3 distributor bonuses
		SELECT lvl2.Lvl1DistributorID [Lvl1DistributorID],
		lvl2.Lvl2DistributorID [Lvl2DistributorID],
		d.ID [Lvl3DistributorID],
		SUM(s.TotalPrice * 0.01) OVER (PARTITION BY d.ID ORDER BY d.ID) as [BonusAmount]
		INTO #Lvl3Distributors 
		FROM #Lvl2Distributors lvl2
		LEFT JOIN Distributors d ON lvl2.Lvl2DistributorID = d.RecommenderID
		LEFT JOIN Sales s ON s.DistributorID = d.ID
		WHERE s.SaleDate BETWEEN @startDate AND @endDate AND s.IncludedInBonus = 0


		INSERT INTO [dbo].[Bonuses]
			   ([DistributorID]
			   ,[BonusAmount])
			   (SELECT ID as [DistributorID],(BonusAmount + 
		ISNULL((SELECT SUM(ISNULL(BonusAmount, 0)) FROM #Lvl2Distributors lvl2 WHERE lvl2.Lvl1DistributorID = lvl1.ID GROUP BY lvl2.Lvl1DistributorID), 0)
		+ ISNULL((SELECT SUM(ISNULL(BonusAmount, 0)) FROM #Lvl3Distributors lvl3 WHERE lvl3.Lvl1DistributorID = lvl1.ID GROUP BY lvl3.Lvl1DistributorID), 0))
		FROM #Lvl1Distributors lvl1)


		UPDATE Sales SET IncludedInBonus = 1 WHERE SaleDate BETWEEN @startDate AND @endDate

		(SELECT ID as [DistributorID],(BonusAmount + 
		ISNULL((SELECT SUM(ISNULL(BonusAmount, 0)) FROM #Lvl2Distributors lvl2 WHERE lvl2.Lvl1DistributorID = lvl1.ID GROUP BY lvl2.Lvl1DistributorID), 0)
		+ ISNULL((SELECT SUM(ISNULL(BonusAmount, 0)) FROM #Lvl3Distributors lvl3 WHERE lvl3.Lvl1DistributorID = lvl1.ID GROUP BY lvl3.Lvl1DistributorID), 0)) AS [BonusAmount]
		FROM #Lvl1Distributors lvl1)
		

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH

END

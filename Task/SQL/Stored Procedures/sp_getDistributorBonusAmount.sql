USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDistributorBonusAmount]    Script Date: 10/12/2022 11:17:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_getDistributorBonusAmount] 
	@distributorId int,
	@result money out
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @result = ISNULL(SUM(BonusAmount), 0) FROM Bonuses WHERE DistributorID = @distributorId 
END

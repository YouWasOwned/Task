USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteDistributorById]    Script Date: 10/12/2022 11:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_deleteDistributorById]
	@distributorId int
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM Distributors WHERE ID = @distributorId)
	BEGIN
		DELETE FROM Distributors WHERE ID = @distributorId
		RETURN 0;
	END
	ELSE 
	BEGIN
		RETURN -1;
	END
END

USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllDistributors]    Script Date: 10/12/2022 11:17:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_getAllDistributors]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Distributors
END

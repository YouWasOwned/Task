USE [Task]
GO
/****** Object:  StoredProcedure [dbo].[sp_registerDistributor]    Script Date: 10/12/2022 11:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_registerDistributor] 
	@name nvarchar(50),
	@surname nvarchar(50),
	@birthDate date,
	@gender int,
	@imagePath nvarchar(200),
	@identificationInformationType int,
	@documentSeries nvarchar(10),
	@documentNumber nvarchar(10),
	@releaseDate date, 
	@termDateOfDocument date,
	@personalNumber nvarchar(50),
	@agency nvarchar(100),
	@contactType int,
	@contactInformation nvarchar(100),
	@addressType int,
	@address nvarchar(100),
	@recommenderId int,
	@level int,
	@recommendedDistributorsCount int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Distributors]
           ([Name]
           ,[Surname]
           ,[BirthDate]
           ,[Gender]
           ,[ImagePath]
           ,[IdentificationInformationType]
           ,[DocumentSeries]
           ,[DocumentNumber]
           ,[ReleaseDate]
           ,[TermDateOfDocument]
           ,[PersonalNumber]
           ,[Agency]
           ,[ContactType]
           ,[ContactInformation]
           ,[AddressType]
           ,[Address]
           ,[RecommenderID]
           ,[Level]
           ,[RecommendedDistributorsCount])
     VALUES
          (@name,
		   @surname,
		   @birthDate,
		   @gender,
		   @imagePath,
		   @identificationInformationType,
		   @documentSeries,
		   @documentNumber,
		   @releaseDate,
		   @termDateOfDocument,
		   @personalNumber,
		   @agency,
		   @contactType,
		   @contactInformation,
		   @addressType,
		   @address,
		   @recommenderId,
		   @level,
		   @recommendedDistributorsCount
		   )
END

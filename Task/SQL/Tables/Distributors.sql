USE [Task]
GO

/****** Object:  Table [dbo].[Distributors]    Script Date: 10/12/2022 11:10:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Distributors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Gender] [int] NOT NULL,
	[ImagePath] [nvarchar](200) NULL,
	[IdentificationInformationType] [int] NOT NULL,
	[DocumentSeries] [nvarchar](10) NULL,
	[DocumentNumber] [nvarchar](10) NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[TermDateOfDocument] [datetime2](7) NOT NULL,
	[PersonalNumber] [nvarchar](50) NOT NULL,
	[Agency] [nvarchar](100) NULL,
	[ContactType] [int] NOT NULL,
	[ContactInformation] [nvarchar](100) NOT NULL,
	[AddressType] [int] NULL,
	[Address] [nvarchar](100) NOT NULL,
	[RecommenderID] [int] NULL,
	[Level] [int] NOT NULL,
	[RecommendedDistributorsCount] [int] NOT NULL,
 CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Distributors] ADD  CONSTRAINT [DF_Distributors_Level]  DEFAULT ((1)) FOR [Level]
GO

ALTER TABLE [dbo].[Distributors] ADD  CONSTRAINT [DF_Distributors_RecommendedDistributorsCount]  DEFAULT ((0)) FOR [RecommendedDistributorsCount]
GO



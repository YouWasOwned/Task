USE [Task]
GO

/****** Object:  Table [dbo].[Bonuses]    Script Date: 10/12/2022 11:08:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bonuses](
	[DistributorID] [int] NOT NULL,
	[BonusAmount] [money] NULL
) ON [PRIMARY]
GO



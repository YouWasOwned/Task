USE [Task]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 10/12/2022 11:11:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UnitPrice] [money] NOT NULL
) ON [PRIMARY]
GO



USE [Task]
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 10/12/2022 11:12:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DistributorID] [int] NOT NULL,
	[SaleDate] [datetime2](7) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[IncludedInBonus] [bit] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sales] ADD  CONSTRAINT [DF_Sales_IncludedInBonus]  DEFAULT ((0)) FOR [IncludedInBonus]
GO



USE [Illuminate]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 02/11/2013 22:15:47 ******/
DROP TABLE [dbo].[Category]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 02/11/2013 22:15:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[ParentCategoryId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



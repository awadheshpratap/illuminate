USE [Illuminate]
GO

if (select count(*) from sys.tables where name = 'Category') = 0
begin 

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

end
GO



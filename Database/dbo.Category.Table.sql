USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Category') > 0
begin 
	drop table Category;
	
	CREATE TABLE [dbo].[Category](
		[CategoryId] [int] NOT NULL,
		[ParentCategoryId] [int] NULL,
		[Name] [nchar](50) NOT NULL
	) ON [PRIMARY]
end;


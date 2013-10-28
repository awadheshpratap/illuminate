USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Category') > 0
begin 
	drop table Category;
	
	CREATE TABLE [dbo].[Category](
		[categoryid] [int] NOT NULL,
		[parentcategoryid] [int] NULL,
		[name] [nchar](50) NOT NULL
	) ON [PRIMARY]
end;


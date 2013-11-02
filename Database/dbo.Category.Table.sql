USE [Illuminate]
GO

if (select count(*) from sys.tables where name = 'Category') = 0
begin 

	CREATE TABLE [dbo].[Category](
		[CategoryId] [int] not null identity(1,1) primary key,
		[ParentCategoryId] [int] NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Description] [nvarchar](500) NULL,

); 

end
GO



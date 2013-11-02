USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Tag') = 0
begin 
	CREATE TABLE [dbo].[Tag](
		[TagId] [int] identity(1,1) PRIMARY KEY,
		[TagName] [nchar](30) NOT NULL
	) 
end;

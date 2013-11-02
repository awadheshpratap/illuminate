USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Tag') = 0
begin 
	

	CREATE TABLE [dbo].[Tag](
		[TagId] [int] NOT NULL,
		[TagName] [nchar](30) NOT NULL
	) ON [PRIMARY]
end;

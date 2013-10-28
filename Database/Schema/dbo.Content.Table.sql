USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Content') > 0
begin 
	
	drop table Content;

	CREATE TABLE [dbo].[Content](
		[contentid] [nchar](10) NULL,
		[author] [nchar](10) NULL,
		[description] [nchar](10) NULL,
		[categorid] [nchar](10) NULL,
		[contenturi] [nchar](10) NULL,
		[contentdata] [nchar](10) NULL,
		[userid] [nchar](10) NULL
	) ON [PRIMARY]
GO

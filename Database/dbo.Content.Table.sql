USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'Content') > 0
begin 
	
	drop table Content;

	CREATE TABLE [dbo].[Content](
		[ContentId] [nchar](10) NULL,
		[Title] [nchar](10) NULL,
		[CategoryId] [nchar](10) NULL,
		[Author] [nchar](10) NULL,
		[Description] [nchar](10) NULL,
		[Data] [nchar](10) NULL,
		[ContentUri] [nchar](10) NULL,
		[CreatorRef] [nchar](10) NULL,
		[UpdaterRef] [nchar](10) NULL,
		[CreationDateTime] [nchar](10) NULL,
		[UpdateDateTime] [nchar](10) NULL,
	) ON [PRIMARY]
GO

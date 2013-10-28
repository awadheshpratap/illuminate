USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentComments') > 0
begin 
	drop table ContentComments;
	
	CREATE TABLE [dbo].[ContentComments](
		[contentid] [nchar](10) NULL,
		[commentedby] [nchar](10) NULL,
		[comments] [nchar](1000) NULL
	) ON [PRIMARY]
end;

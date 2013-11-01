USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentComments') > 0
begin 
	drop table ContentComments;
	
	CREATE TABLE [dbo].[ContentComments](
		[ContentId] [nchar](10) NULL,
		[CommentedBy] [nchar](10) NULL,
		[Comments] [nchar](1000) NULL
	) ON [PRIMARY]
end;

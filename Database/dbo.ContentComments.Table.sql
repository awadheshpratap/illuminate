USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentComments') = 0
begin 
	CREATE TABLE [dbo].[ContentComments](
		[ContentId] int not null Identity(1,1) Primary Key,
		[CommentedBy] [nchar](10) NULL,
		[Comments] [nchar](1000) NULL
	) ON [PRIMARY]
end;

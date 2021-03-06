USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentComments') = 0
begin 
	CREATE TABLE [dbo].[ContentComments](
		[Id] [int] not null IDENTITY(1,1) PRIMARY KEY,
		[ContentId] [int] not null,
		[CommentedBy] [nchar](10) not null,
		[Comments] [nchar](1000) NULL
	) ON [PRIMARY]
end;

USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentLikes') = 0
begin 
	
	CREATE TABLE [dbo].[ContentLikes](
		[contentid] INT not null identity(1,1) Primary Key,
		[userid] [nchar](20) NOT NULL,
		[likestatus] BIT NULL
	) ON [PRIMARY]
end;

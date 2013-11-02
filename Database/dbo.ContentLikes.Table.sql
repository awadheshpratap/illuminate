USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentLikes') = 0
begin 
	
	CREATE TABLE [dbo].[ContentLikes](
		[contentid] INT NOT NULL,
		[userid] [nchar](20) NOT NULL,
		[likestatus] BIT NULL
	) ON [PRIMARY]
end;

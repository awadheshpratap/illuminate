USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentLikes') = 0
begin 
	
	CREATE TABLE [dbo].[ContentLikes](
		[Id] [int] not null IDENTITY(1,1) PRIMARY KEY,
		[contentid] INT not null,
		[userid] [nchar](20) not null,
		[likestatus] BIT NULL
	) ON [PRIMARY]
end;

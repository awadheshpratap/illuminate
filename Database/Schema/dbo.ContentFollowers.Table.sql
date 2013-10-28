USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentFollowers') > 0
begin 
	
	drop table ContentFollowers;
	
	CREATE TABLE [dbo].[ContentFollowers](
		[contentid] int NOT NULL,
		[followedby] [nchar](20) NOT NULL
	) ON [PRIMARY]
end;
GO

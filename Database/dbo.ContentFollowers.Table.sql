USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentFollowers') = 0
begin 
	CREATE TABLE [dbo].[ContentFollowers](
		[contentid] int not null identity(1,1) primary key,
		[followedby] [nchar](20) NOT NULL
	)
end

GO

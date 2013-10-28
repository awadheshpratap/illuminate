USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'UserProfile') > 0
begin 
	
	drop table UserProfile;
	
	CREATE TABLE [dbo].[UserProfile](
		[userid] [nchar](20),
		[username] [nchar](50),
		[email] [nchar](50) Null,
		[likes] int NULL,
		[comments] int NULL
	) ON [PRIMARY]
end;

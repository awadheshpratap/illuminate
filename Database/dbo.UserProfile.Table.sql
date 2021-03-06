USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'UserProfile') = 0
begin 
 CREATE TABLE [dbo].[UserProfile](
		[UserId] [nchar](20) PRIMARY KEY,
		[UserName] [nchar](50),
		[Email] [nchar](50) Null,
		[Likes] int NULL,
		[Comments] int NULL
	) ON [PRIMARY]
end;
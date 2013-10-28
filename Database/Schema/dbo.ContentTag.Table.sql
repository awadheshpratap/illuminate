USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentTag') > 0
begin 
	
	drop tables ContentTag;
	
	CREATE TABLE [dbo].[ContentTag](
		[tagid] int NOT NULL,
		[contentid] int NOT NULL,
		[taggedby] [nchar](20) NOT NULL,
		[text] [nchar](200) NULL
	) ON [PRIMARY]
end;
GO

USE [illuminate]
GO
if (select count(*) from sys.tables where name = 'ContentTag') > 0
begin 
	
	drop tables ContentTag;
	
	CREATE TABLE [dbo].[ContentTag](
		[ContentId] int NOT NULL,
		[TagId] int NOT NULL,
		[TaggedBy] [nchar](20) NOT NULL,
		[Description] [nchar](200) NULL
	) ON [PRIMARY]
end;
GO

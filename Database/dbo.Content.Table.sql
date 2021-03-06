USE [Illuminate]
GO

if (select count(*) from sys.tables where name = 'Content') = 0
begin 
CREATE TABLE [dbo].[Content](
	[Id] [int] not null IDENTITY(1,1) PRIMARY KEY,
	[Title] [nvarchar](500) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Description] [text] NULL,
	[Data] [text] NULL,
	[Uri] [nvarchar](500) NULL,
	[CreatorRef] [nvarchar](50) NOT NULL,
	[UpdaterRef] [nvarchar](50) NOT NULL,
	[CreationDateTime] [date] NOT NULL,
	[UpdateDateTime] [date] NOT NULL,
 )
 end
 
 



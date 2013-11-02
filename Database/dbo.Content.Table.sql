USE [Illuminate]
GO

if (select count(*) from sys.tables where name = 'Content') = 0
begin 
CREATE TABLE [dbo].[Content](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
end
GO



use AppDB

CREATE TABLE [dbo].[SysSample](
[Id] [varchar](50) NOT NULL,
[Name] [varchar](50) NULL,
[Age] [int] NULL,
[Bir] [datetime] NULL,
[Photo] [varchar](50) NULL,
[Note] [text] NULL,
[CreateTime] [datetime] NULL,
CONSTRAINT [PK__SysSampl__3214EC075AEE82B9] PRIMARY KEY CLUSTERED
(
	[Id] desc
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo],[Note], [CreateTime]) values('1', N'张三', 18, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('11', N'张三', 18, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('2', N'李四', 21, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('22', N'李四', 21, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('3', N'王五', 33, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('33', N'王五', 33, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('4', N'柳六', 24, '10/1/1991 12:00AM', NULL, NULL, '01/1 2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('44', N'柳六', 24, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('5', N'X七', 65, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00')
INSERT INTO[SysSample]([Id], [Name], [Age], [Bir], [Photo], [Note], [CreateTime]) values('55', N'X七', 65, '10/1/1991 12:00AM', NULL, NULL, '01/1/2013 12:00AM')

﻿use AppDB

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


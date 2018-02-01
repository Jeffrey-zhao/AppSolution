
USE [AppDB]
GO

/****** Object:  Table [dbo].[MIS_Article_Category]    Script Date: 05/15/2014 17:37:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MIS_Article_Category](
    [Id] [nvarchar](50) NOT NULL, --主键
    [ChannelId] [int] NULL,  --预留字段
    [Name] [nvarchar](100) NOT NULL, --类别名
    [ParentId] [nvarchar](50) NULL, --上级ID
    [Sort] [int] NULL, --排序
    [ImgUrl] [nvarchar](255) NULL,--图片
    [BodyContent] [nvarchar](4000) NULL,--描述
    [CreateTime] [datetime] NULL,--创建时间
    [Enable] [bit] NOT NULL, --是否启用
 CONSTRAINT [PK__MIS_Arti__3214EC077DCDAAA2] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MIS_Article_Category]  WITH NOCHECK ADD  CONSTRAINT [FK_MIS_Article_Category_MIS_Article_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[MIS_Article_Category] ([Id])
GO

ALTER TABLE [dbo].[MIS_Article_Category] NOCHECK CONSTRAINT [FK_MIS_Article_Category_MIS_Article_Category]
GO

ALTER TABLE [dbo].[MIS_Article_Category] ADD  CONSTRAINT [DF__MIS_Artic__Paren__7FB5F314]  DEFAULT ((0)) FOR [ParentId]
GO

ALTER TABLE [dbo].[MIS_Article_Category] ADD  CONSTRAINT [DF__MIS_Artic__Creat__00AA174D]  DEFAULT (getdate()) FOR [CreateTime]
GO


use AppDB

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MIS_Article](
    [Id] [nvarchar](50) NOT NULL,   --主键
    [ChannelId] [int] NOT NULL,    --频道（预留字段，以后可能需要扩张）
    [CategoryId] [nvarchar](50) NOT NULL, --类别
    [Title] [nvarchar](100) NOT NULL,  --标题
    [ImgUrl] [nvarchar](255) NULL,   --图片
    [BodyContent] [nvarchar](4000) NULL, --内容
    [Sort] [int] NULL,    --排序
    [Click] [int] NULL,   --访问次数
    [CheckFlag] [int] NOT NULL, --是否审核
    [Checker] [nvarchar](50) NULL, --审核人
    [CheckDateTime] [datetime] NULL, --审核时间
    [Creater] [nvarchar](50) NULL, --创建人
    [CreateTime] [datetime] NULL, --创建时间
 CONSTRAINT [PK__MIS_Arti__3214EC07038683F8] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MIS_Article]  WITH CHECK ADD  CONSTRAINT [FK_MIS_Article_MIS_Article_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[MIS_Article_Category] ([Id])
GO

ALTER TABLE [dbo].[MIS_Article] CHECK CONSTRAINT [FK_MIS_Article_MIS_Article_Category]
GO

ALTER TABLE [dbo].[MIS_Article]  WITH CHECK ADD  CONSTRAINT [FK_MIS_Article_SysUser] FOREIGN KEY([Creater])
REFERENCES [dbo].[SysUser] ([Id])
GO

ALTER TABLE [dbo].[MIS_Article] CHECK CONSTRAINT [FK_MIS_Article_SysUser]
GO

ALTER TABLE [dbo].[MIS_Article]  WITH NOCHECK ADD  CONSTRAINT [FK_MIS_Article_SysUser1] FOREIGN KEY([Checker])
REFERENCES [dbo].[SysUser] ([Id])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[MIS_Article] CHECK CONSTRAINT [FK_MIS_Article_SysUser1]
GO

ALTER TABLE [dbo].[MIS_Article] ADD  CONSTRAINT [DF_MIS_Article_CheckFlag]  DEFAULT ((0)) FOR [CheckFlag]
GO

ALTER TABLE [dbo].[MIS_Article] ADD  CONSTRAINT [DF__MIS_Artic__Creat__056ECC6A]  DEFAULT (getdate()) FOR [CreateTime]
GO

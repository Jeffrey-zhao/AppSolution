
use AppDB
--insert SysModuleOperate
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleCreate', N'创建', 'Create', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleDelete', N'删除', 'Delete', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleDetails', N'详细', 'Details', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleEdit', N'编辑', 'Edit', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleExport', N'导出', 'Export', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleQuery', N'查询', 'Query', 'BaseSample', 0, 0)
INSERT INTO[SysModuleOperate]([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) values('BaseSampleSave', N'保存', 'Save', 'BaseSample', 0, 0)

--insert SysRole
INSERT INTO[SysRole]([Id], [Name], [Description], [CreateTime], [CreatePerson]) values('administrator', N'超级管理员', N'全部授权', '10/1/2012 12:00AM', 'Administrator')

--insert SysRight
INSERT INTO[SysRight]([Id], [ModuleId], [RoleId], [Rightflag]) values('administratorSampleFile', 'SampleFile', 'administrator', 1)
INSERT INTO[SysRight]([Id], [ModuleId], [RoleId], [Rightflag]) values('administratorBaseSample', 'BaseSample', 'administrator', 1)

--insert SysRightOperate
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleCreate', 'administratorBaseSample', 'Create', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleDelete', 'administratorBaseSample', 'Delete', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleDetails', 'administratorBaseSample', 'Details', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleEdit', 'administratorBaseSample', 'Edit', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleExport', 'administratorBaseSample', 'Export', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleQuery', 'administratorBaseSample', 'Query', 1)
INSERT INTO[SysRightOperate]([Id], [RightId], [KeyCode], [IsValid]) values('administratorBaseSampleSave', 'administratorBaseSample', 'Save', 1)

--insert SysUser
INSERT INTO[SysUser]([Id], [UserName], [Password], [TrueName], [Card], [MobileNumber], [PhoneNumber], [QQ], [EmailAddress], [OtherContact], [Province],
 [City], [Village], [Address], [State], [CreateTime], [CreatePerson], [Sex], [Birthday], [JoinDate], [Marital], [Political], [Nationality], [Native], [School], 
[Professional], [Degree], [DepId], [PosId], [Expertise], [JobState], [Photo], [Attach])
values('admin', 'admin', '01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00', N'系统管理员', NULL, NULL,'06638888888', '324345345', 'ymnets@sina.com', 
N'MSN：ymnets', '440000', '440100', '440101',N'小小村落', 1, '11/18/2012  3:40PM', 'admin', N'男', '05/18/1900 12:00AM', '01/1/2013 12:00AM', N'未婚', 
N'中国', N'中国', N'广东揭阳', N'美国哈佛大学', N'计算机工程', N'硕士', '20000', '20001', N'勤劳向学,为人友善,乐于助人', N'在职', NULL, NULL)

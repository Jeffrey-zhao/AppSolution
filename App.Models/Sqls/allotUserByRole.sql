use AppDB
go

Create proc [dbo].[P_Sys_GetUserByRoleId]
@RoleId varchar(50)
as
begin
--读取角色所包含的用户
select a.*,ISNULL(b.SysUserId,0) as flag from SysUser a left join
SysRoleSysUser b on a.Id=b.SysUserId
and b.SysRoleId=@RoleId
order by b.SysRoleId desc
end 

go

--Create PROCEDURE [dbo].[P_Sys_UpdateSysRoleSysUser]
--@roleId varchar(50),@userId varchar(50)
--AS
----更新角色用户中间关系表
--BEGIN
--    insert into SysRoleSysUser(SysRoleId,SysUserId)
--        values(@roleId,@userId)
--END

go

Create PROCEDURE [dbo].[P_Sys_DeleteSysRoleSysUserByRoleId]
@roleId varchar(50)
AS
--更新角色用户中间关系表,前删除关联
BEGIN
    delete SysRoleSysUser where SysRoleId=@roleId
END
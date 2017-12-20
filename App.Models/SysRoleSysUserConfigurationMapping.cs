using System.Data.Entity.ModelConfiguration;

namespace App.Models
{
    public class SysRoleSysUserConfigurationMapping : EntityTypeConfiguration<SysRole>
    {
        public SysRoleSysUserConfigurationMapping()
        {
            HasMany(x => x.SysUser)
                .WithMany(x => x.SysRole)
                .Map(m =>
                {
                    m.MapLeftKey("SysRoleId");
                    m.MapRightKey("SysUserId");
                    m.ToTable("SysRoleSysUser");
                });
        }
    }
}
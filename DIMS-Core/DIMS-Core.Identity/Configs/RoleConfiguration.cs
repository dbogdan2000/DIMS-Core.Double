using System.Collections.Generic;
using DIMS_Core.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIMS_Core.Identity.Configs
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(GetRolesData());
        }

        private IEnumerable<Role> GetRolesData()
        {
            for (var i = 0; i < IdentityConstants.RoleNames.Roles.Length; i++)
            {
                yield return new Role
                             {
                                 Id = i + 1,
                                 Name = IdentityConstants.RoleNames.Roles[i]
                             };
            }
        }
    }
}
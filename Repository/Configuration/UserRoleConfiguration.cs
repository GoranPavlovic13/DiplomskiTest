using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "f0091af6-14ee-4c5e-b913-30f987bac393",
                    RoleId = "0b549254-d114-4132-b4f2-2e606080e507" 
                },
                new IdentityUserRole<string>
                {
                    UserId = "a3da7156-4cca-44c8-ac03-2d6995589237",
                    RoleId = "23763795-6463-49b2-bc48-1348ce231ab0"
                }
            );
        }
    }
}

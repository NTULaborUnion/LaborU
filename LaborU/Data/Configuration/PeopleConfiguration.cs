using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborU.Data.Configuration
{
    public class PeopleConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne(h => h.CreatedUser).WithMany(w => w.CreatedPeople).HasForeignKey(fk => fk.CreatedUserId);
            builder.HasOne(h => h.User).WithMany(w => w.RelatedContacts).HasForeignKey(fk=>fk.UserId);
            builder.HasIndex(i => i.Email).IsUnique();
        }
    }
}

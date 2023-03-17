using LaborU.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborU.Data.Configuration;

public class ContactContactTypeConfiguration : IEntityTypeConfiguration<ContactContactType>
{
    public void Configure(EntityTypeBuilder<ContactContactType> builder)
    {
        builder.HasKey(k => new
        {
            k.ContactId, k.TypeId
        });
    }
}
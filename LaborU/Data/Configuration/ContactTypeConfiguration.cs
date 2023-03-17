using System.Collections.Generic;
using LaborU.Mappers;
using LaborU.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborU.Data.Configuration;

public class ContactTypeConfiguration:IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> builder)
    {
        builder.HasData(new List<ContactType>()
        {
            new ContactType()
            {
                Id = 1,
                Name = "捐款者"
            },
            new ContactType()
            {
                Id = 2,
                Name = "一般會員"
            },
            new ContactType()
            {
                Id = 3,
                Name = "贊助會員"
            }
        });
    }
}
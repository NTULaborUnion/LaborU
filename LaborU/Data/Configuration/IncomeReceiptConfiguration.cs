using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborU.Data.Configuration
{
    public class IncomeReceiptConfiguration : IEntityTypeConfiguration<IncomeReceipt>
    {
        public void Configure(EntityTypeBuilder<IncomeReceipt> builder)
        {
            builder.HasOne(h => h.CreatedUser).WithMany(w => w.CreatedIncomeReceipt)
                .HasForeignKey(fk => fk.CreatedUserId);
            builder.HasMany(h => h.Items).WithOne(w => w.Receipt).HasForeignKey(fk => fk.ReceiptId);
            builder.HasOne(h => h.To).WithMany(w => w.IncomeReceipts).HasForeignKey(fk => fk.ToPeopleId);
            builder.HasOne(h => h.Shipment).WithMany(w => w.IncomeReceipts).HasForeignKey(fk => fk.ShipmentId);
        }
    }
}

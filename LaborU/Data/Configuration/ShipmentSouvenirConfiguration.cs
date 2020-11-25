using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborU.Data.Configuration
{
    public class ShipmentSouvenirConfiguration : IEntityTypeConfiguration<ShipmentSouvenir>
    {
        public void Configure(EntityTypeBuilder<ShipmentSouvenir> builder)
        {
            builder.HasKey(k => new {k.ShipmentId, k.SouvenirId});
            builder.HasOne(h => h.Shipment).WithMany(w => w.ShipmentSouvenirs).HasForeignKey(fk => fk.SouvenirId);
            builder.HasOne(h => h.Shipment).WithMany(w => w.ShipmentSouvenirs).HasForeignKey(fk => fk.ShipmentId);
        }
    }
}

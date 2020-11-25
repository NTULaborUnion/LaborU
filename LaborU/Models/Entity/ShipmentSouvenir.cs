using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.Entity
{
    public class ShipmentSouvenir
    {
        public Guid ShipmentId { get; set; }
        public Guid SouvenirId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual Souvenir Souvenir { get; set; }
    }
}

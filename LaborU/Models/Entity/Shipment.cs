using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.Entity
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public string Address { get; set; }
        public Guid? PeopleId { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<ShipmentSouvenir> ShipmentSouvenirs { get; set; }
        public virtual ICollection<IncomeReceipt> IncomeReceipts { get; set; }
    }
}

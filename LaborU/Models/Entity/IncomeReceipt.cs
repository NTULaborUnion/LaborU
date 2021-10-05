using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Models.Entity.Identity;
using Microsoft.AspNetCore.Identity;

namespace LaborU.Models.Entity
{
    public class IncomeReceipt
    {
        public IncomeReceipt()
        {
            Items = new List<IncomeReceiptItem>();
        }
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid ToPeopleId { get; set; }
        public virtual People To { get; set; }
        public double Total { get; set; }
        public string ManagerNote { get; set; }
        public string PeopleNote { get; set; }
        public Guid CreatedUserId { get; set; }
        public virtual ICollection<IncomeReceiptItem> Items { get; set; }
        public virtual LaborUUser CreatedUser { get; set; }
        public IncomeReceiptType Type { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid? ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
    }

    public enum IncomeReceiptType
    {
        MembershipFee,
        Donation
    }
}

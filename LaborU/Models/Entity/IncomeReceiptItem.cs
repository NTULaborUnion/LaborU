using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.Entity
{
    public class IncomeReceiptItem
    {
        public Guid Id { get; set; }
        public Guid ReceiptId { get; set; }
        public virtual IncomeReceipt Receipt { get; set; }
        public string Note { get; set; }
        public double Amount { get; set; }
    }
}

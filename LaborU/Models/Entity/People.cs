using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.Entity
{
    public class People
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<IncomeReceipt> IncomeReceipts { get; set; }
    }
}

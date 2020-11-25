using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Models.Entity.Identity;

namespace LaborU.Models.Entity
{
    public class People
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid CreatedUserId { get; set; }
        public virtual LaborUUser CreatedUser { get; set; }

        public virtual ICollection<IncomeReceipt> IncomeReceipts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using LaborU.Models.Entity.Identity;

namespace LaborU.Models.Entity
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid? UserId { get; set; }
        public virtual IEnumerable<ContactContactType> Types { get; set; }
        public virtual LaborUUser? User { get; set; }
        public virtual LaborUUser CreatedUser { get; set; }

        public virtual ICollection<IncomeReceipt> IncomeReceipts { get; set; }
    }
}

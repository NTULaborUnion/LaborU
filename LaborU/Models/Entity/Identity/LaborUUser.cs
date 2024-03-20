using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LaborU.Models.Entity.Identity
{
    public class LaborUUser:IdentityUser<Guid>
    {
        public LaborUUser():base()
        {
            CreatedIncomeReceipt = new List<IncomeReceipt>();
            CreatedPeople = new List<Contact>();
        }
        public ICollection<IncomeReceipt> CreatedIncomeReceipt { get; set; }
        public ICollection<Contact> CreatedPeople { get; set; }
        public ICollection<Contact> RelatedContacts { get; set; }
    }
}

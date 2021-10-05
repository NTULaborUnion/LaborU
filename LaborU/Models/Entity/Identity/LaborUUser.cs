using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LaborU.Models.Entity.Identity
{
    public class LaborUUser:IdentityUser<Guid>
    {
        public LaborUUser():base()
        {
            CreatedIncomeReceipt = new List<IncomeReceipt>();
            CreatedPeople = new List<People>();
        }
        public ICollection<IncomeReceipt> CreatedIncomeReceipt { get; set; }
        public ICollection<People> CreatedPeople { get; set; }
    }
}

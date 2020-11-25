using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LaborU.Models.Entity.Identity
{
    public class LaborUUser:IdentityUser
    {
        public LaborUUser():base()
        {
            CreatedIncomeReceipt=new List<IncomeReceipt>();
        }
        public ICollection<IncomeReceipt> CreatedIncomeReceipt { get; set; }
    }
}

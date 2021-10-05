using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.ViewModels
{
    public class PeopleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}

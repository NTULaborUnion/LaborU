using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborU.Models.Entity
{
    public class Souvenir
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public int Remain { get; set; }
        public double Price { get; set; }
    }
}

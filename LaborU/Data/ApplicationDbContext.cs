using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LaborU.Data.Configuration;
using LaborU.Models.Entity;

namespace LaborU.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<IncomeReceipt> IncomeReceipt { get; set; }
        public virtual DbSet<IncomeReceiptItem> IncomeReceiptItem { get; set; }
        public virtual DbSet<People> Peoples { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new IncomeReceiptConfiguration());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreReport.Models;

namespace StoreReport.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StoreReport.Models.Franchise> Franchise { get; set; }
        public DbSet<StoreReport.Models.Store> Store { get; set; }
        public DbSet<StoreReport.Models.Checks> Checks { get; set; }
        public DbSet<StoreReport.Models.ProductType> ProductType { get; set; }
        public DbSet<StoreReport.Models.Item> Item { get; set; }
        public DbSet<StoreReport.Models.User> User { get; set; }
        public DbSet<StoreReport.Models.StoresByRoute> StoresByRoute { get; set; }
     
    }
}

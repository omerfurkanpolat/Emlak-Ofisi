using EmlakOfisi.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakOfisi.Dal.Concrete.EntityFramework
{
    public class EmlakOfisiContext:IdentityDbContext<User,Role,int>
    {
        public EmlakOfisiContext()
        {

        }
        public EmlakOfisiContext(DbContextOptions<EmlakOfisiContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmlakOfisiDB;Trusted_Connection=true");
           
        }
        public DbSet<AgentCompany> AgentCompanies { get; set; }
        public DbSet<StateAd> StateAds { get; set; }
    }
}

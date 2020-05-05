using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Project_DBEntities") { }
        public DbSet<Autoriai> Autoriai { get; set; }
        public DbSet<Kalbo> Kalbos { get; set; }
        public DbSet<Zanrai> Zanrai { get; set; }
        public DbSet<Knygo> Knygos { get; set; }
        public DbSet<Tipai> Tipai { get; set; }
        public DbSet<AutoriaiDouble> AutoriaiDoubles { get; set; }
        public DbSet<Skaitytojai> Skaitytojai { get; set; }
        public DbSet<SkaitytojaiDouble> SkaitytojaiDoubles { get; set; }
    }
}

using CaimanProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.DAL
{
    public class DbCaimanContext : DbContext
    {

        /* 

         public DbSet<SocialNetwork> SocialNetworks { get; set; }

         public DbSet<Transport> Transports { get; set; }

         
  public DbSet<Competence> Competences { get; set; }
         public DbSet<Associ> Associs { get; set; }*/
        public DbSet<Member> Members { get; set; }
        public DbSet<Specialite> Specialites { get; set; }
       
        public DbSet<Contact> Contacts { get; set; }
       
        public DbSet<Projet> Projets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=192.168.70.96;Initial Catalog=DbCaiman;Integrated Security=True"));
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associ>()
                   .HasKey(m => new { m.ProjetId, m.MemberId });
            modelBuilder.Entity<Associ>()
                .HasOne(m => m.Member)
                .WithMany(ma => ma.AssocisProjetsMember)
                .HasForeignKey(m => m.MemberId);

            modelBuilder.Entity<Associ>()
                 .HasOne(m => m.Projet)
                 .WithMany(ma => ma.AssocisProjetsMember)
                 .HasForeignKey(m => m.ProjetId);

        }*/
    }
}
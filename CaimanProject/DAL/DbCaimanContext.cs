
using CaimanProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace CaimanProject.DAL
{
    public class DbCaimanContext : DbContext
    {

        public DbSet<Member> Members { get; set; }

        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Projet> Projets { get; set; }

        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Associ> Associs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=DbCaiman;Integrated Security=True"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associ>()
                .HasKey(m => new { m.ProjetId, m.MemberId });
            modelBuilder.Entity<Associ>()
                .HasOne(me => me.Member)
                .WithMany(m =>m.AssocisMemberProjet)
                .HasForeignKey(me => me.MemberId);  
            
            modelBuilder.Entity<Associ>()
                .HasOne(me => me.Projet)
                .WithMany(m =>m.AssocisMemberProjet)
                .HasForeignKey(me =>me.ProjetId);
        }
    }
}
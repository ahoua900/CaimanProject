
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



       /* public DbSet<SocialNetwork> SocialNetworks { get; set; }

        public DbSet<Transport> Transports { get; set; }


       */
       /* public DbSet<Associ> Associs { get; set; }*/
        public DbSet<Member> Members { get; set; } 
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<NoteP> NotePs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
       
        public DbSet<Projet> Projets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1MOS7C0;Initial Catalog=DbCaiman;Integrated Security=True"));
        }

        
    }
}
﻿// <auto-generated />
using System;
using CaimanProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaimanProject.Migrations
{
    [DbContext(typeof(DbCaimanContext))]
    [Migration("20200818141710_ajoutdeprojet")]
    partial class ajoutdeprojet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaimanProject.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactFonction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("ContactPname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CaimanProject.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberCommune")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MemberIsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("MemberLieuNaissance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberMissionActive")
                        .HasColumnType("int");

                    b.Property<int>("MemberMissonFin")
                        .HasColumnType("int");

                    b.Property<DateTime>("MemberNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberNote")
                        .HasColumnType("int");

                    b.Property<int>("MemberPhone")
                        .HasColumnType("int");

                    b.Property<string>("MemberPnom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberQuartier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberSex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CaimanProject.Models.NoteP", b =>
                {
                    b.Property<int>("NotePId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("NotePDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotePDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjetNoteProjetId")
                        .HasColumnType("int");

                    b.HasKey("NotePId");

                    b.HasIndex("ProjetNoteProjetId");

                    b.ToTable("NoteP");
                });

            modelBuilder.Entity("CaimanProject.Models.Projet", b =>
                {
                    b.Property<int>("ProjetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BilanProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjetCahierCharge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProjetDateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProjetDateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjetDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetMoney")
                        .HasColumnType("int");

                    b.Property<string>("ProjetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetProgressBar")
                        .HasColumnType("int");

                    b.HasKey("ProjetId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("CaimanProject.Models.Specialite", b =>
                {
                    b.Property<int>("SpecialiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageSpecialité")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialiteColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialiteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url_Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialiteId");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("CaimanProject.Models.NoteP", b =>
                {
                    b.HasOne("CaimanProject.Models.Projet", "ProjetNote")
                        .WithMany("NoteP")
                        .HasForeignKey("ProjetNoteProjetId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolomentor.Data;

#nullable disable

namespace kolomentor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240124213049_Initial3")]
    partial class Initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kolomentor.Models.Career", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Careers");
                });

            modelBuilder.Entity("kolomentor.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CareerCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MentorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("kolomentor.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pdf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("kolomentor.Models.Mentee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CareerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("EducationLevel")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExecutiveSummary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CareerId");

                    b.HasIndex("MentorId");

                    b.ToTable("Mentees");
                });

            modelBuilder.Entity("kolomentor.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CareerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExecutiveSummary")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PlaceOfWork")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CareerId");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("kolomentor.Models.MentorMenteeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CareerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MenteeId")
                        .HasColumnType("int");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CareerId");

                    b.HasIndex("MenteeId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorsMentees");
                });

            modelBuilder.Entity("kolomentor.Models.Mentor_Material", b =>
                {
                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("MentorId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Mentors_Materials");
                });

            modelBuilder.Entity("kolomentor.Models.Mentorship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MenteeId")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenteeId");

                    b.HasIndex("MentorId");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("kolomentor.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MentorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("kolomentor.Models.SkillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SkillId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SkillTypeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillTypeTitleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillTypes");
                });

            modelBuilder.Entity("kolomentor.Models.SkillTypeTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SkillTypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SkillTypeTopicDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillTypeTopicTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkillTypeId");

                    b.ToTable("SkillTypeTopics");
                });

            modelBuilder.Entity("kolomentor.Models.Guest", b =>
                {
                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany("Guests")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.Mentee", b =>
                {
                    b.HasOne("kolomentor.Models.Career", "Career")
                        .WithMany("Mentees")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany("Mentees")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Career");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.Mentor", b =>
                {
                    b.HasOne("kolomentor.Models.Career", "Career")
                        .WithMany("Mentors")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Career");
                });

            modelBuilder.Entity("kolomentor.Models.MentorMenteeModel", b =>
                {
                    b.HasOne("kolomentor.Models.Career", "Career")
                        .WithMany()
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolomentor.Models.Mentee", "Mentee")
                        .WithMany()
                        .HasForeignKey("MenteeId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Career");

                    b.Navigation("Mentee");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.Mentor_Material", b =>
                {
                    b.HasOne("kolomentor.Models.Material", "Material")
                        .WithMany("Mentors_Materials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany("Mentors_Materials")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.Mentorship", b =>
                {
                    b.HasOne("kolomentor.Models.Mentee", "Mentee")
                        .WithMany()
                        .HasForeignKey("MenteeId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Mentee");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.Skill", b =>
                {
                    b.HasOne("kolomentor.Models.Mentor", "Mentor")
                        .WithMany("Skills")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("kolomentor.Models.SkillType", b =>
                {
                    b.HasOne("kolomentor.Models.Skill", "Skill")
                        .WithMany("SkillTypes")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("kolomentor.Models.SkillTypeTopic", b =>
                {
                    b.HasOne("kolomentor.Models.SkillType", "SkillType")
                        .WithMany("SkillTypeTopics")
                        .HasForeignKey("SkillTypeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("SkillType");
                });

            modelBuilder.Entity("kolomentor.Models.Career", b =>
                {
                    b.Navigation("Mentees");

                    b.Navigation("Mentors");
                });

            modelBuilder.Entity("kolomentor.Models.Material", b =>
                {
                    b.Navigation("Mentors_Materials");
                });

            modelBuilder.Entity("kolomentor.Models.Mentor", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("Mentees");

                    b.Navigation("Mentors_Materials");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("kolomentor.Models.Skill", b =>
                {
                    b.Navigation("SkillTypes");
                });

            modelBuilder.Entity("kolomentor.Models.SkillType", b =>
                {
                    b.Navigation("SkillTypeTopics");
                });
#pragma warning restore 612, 618
        }
    }
}

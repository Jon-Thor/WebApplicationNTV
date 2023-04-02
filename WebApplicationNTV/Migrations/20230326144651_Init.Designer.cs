﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationNTV.Data;

#nullable disable

namespace WebApplicationNTV.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230326144651_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            Name = "H22-FK1"
                        },
                        new
                        {
                            GroupId = 2,
                            Name = "H22-FK2"
                        },
                        new
                        {
                            GroupId = 3,
                            Name = "H22-FK3"
                        });
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Marks", b =>
                {
                    b.Property<int>("MarksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarksId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("MarksId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "F1rstName",
                            GroupId = 1,
                            LastName = "LastName"
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "FirstN2me",
                            GroupId = 2,
                            LastName = "L2stN2me"
                        },
                        new
                        {
                            StudentId = 3,
                            FirstName = "FirstNam3",
                            GroupId = 3,
                            LastName = "LastNam3"
                        });
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            Title = "Programming"
                        },
                        new
                        {
                            SubjectId = 2,
                            Title = "Programming2"
                        },
                        new
                        {
                            SubjectId = 3,
                            Title = "Programming3"
                        });
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Hjörtur",
                            LastName = "Pálmi"
                        },
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Hjörtur",
                            LastName = "Pálmi"
                        });
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("WebApplicationNTV.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationNTV.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Marks", b =>
                {
                    b.HasOne("WebApplicationNTV.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationNTV.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WebApplicationNTV.Models.Student", b =>
                {
                    b.HasOne("WebApplicationNTV.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}

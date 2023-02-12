﻿// <auto-generated />
using System;
using Document.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Document.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Document.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                            CreatedAt = new DateTime(2023, 2, 12, 16, 50, 45, 478, DateTimeKind.Utc).AddTicks(9890),
                            Name = "РТСУ"
                        });
                });

            modelBuilder.Entity("Document.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Correspondent")
                        .HasColumnType("TEXT");

                    b.Property<string>("CorrespondentNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAtCorrespondent")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<string>("Topic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Document.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Новый"
                        },
                        new
                        {
                            Id = 2,
                            Name = "В процессе"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Отказано"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Одобрено"
                        });
                });

            modelBuilder.Entity("Document.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d1778f6-800e-413e-9f1e-496d8cdb612c"),
                            CreatedAt = new DateTime(2023, 2, 12, 16, 50, 45, 572, DateTimeKind.Utc).AddTicks(9490),
                            DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                            Name = "Админ",
                            Password = "$2b$10$Mf0hbs7LruLOcVir37XizOjmsyu8AEx0i82Siqne4mlLK5oXr80Ke",
                            Phone = "+000000000000"
                        },
                        new
                        {
                            Id = new Guid("822f7ffc-f18c-4fb6-ac33-19dc2761b84c"),
                            CreatedAt = new DateTime(2023, 2, 12, 16, 50, 45, 732, DateTimeKind.Utc).AddTicks(5180),
                            DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                            Name = "Гость",
                            Password = "$2b$10$BXbbDRqd5aBQW.J359mfvOsE2JVNqh2G9bHu/htvyP3H8fI8kzco2",
                            Phone = "+000000000001"
                        });
                });

            modelBuilder.Entity("Document.Models.UserDocuments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDocuments");
                });

            modelBuilder.Entity("Document.Models.Document", b =>
                {
                    b.HasOne("Document.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Document.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Document.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Document.Models.User", b =>
                {
                    b.HasOne("Document.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Document.Models.UserDocuments", b =>
                {
                    b.HasOne("Document.Models.Document", "Document")
                        .WithMany("UserDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Document.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Document.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Document.Models.Document", b =>
                {
                    b.Navigation("UserDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}

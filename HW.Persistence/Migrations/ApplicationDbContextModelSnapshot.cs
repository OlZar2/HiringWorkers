﻿// <auto-generated />
using System;
using HW.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW.Core.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("HW.Core.Entities.Company", b =>
                {
                    b.HasBaseType("HW.Core.Entities.Account");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("HW.Core.Entities.User", b =>
                {
                    b.HasBaseType("HW.Core.Entities.Account");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("HW.Core.Entities.Account", b =>
                {
                    b.OwnsOne("HW.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("AccountId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsOne("HW.Core.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("AccountId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("HW.Core.Entities.Company", b =>
                {
                    b.HasOne("HW.Core.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("HW.Core.Entities.Company", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HW.Core.Entities.User", b =>
                {
                    b.HasOne("HW.Core.Entities.Account", null)
                        .WithOne()
                        .HasForeignKey("HW.Core.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("HW.Core.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("Patronymic")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Patronymic");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("SecondName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

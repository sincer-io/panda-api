﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManagerApi.Data;

namespace MoneyManagerApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190406134000_InititialCreate")]
    partial class InititialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MoneyManagerApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsExtraneous");

                    b.Property<string>("Label");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.TransactionPerson", b =>
                {
                    b.Property<int>("TransactionId");

                    b.Property<int>("PersonId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TransactionId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("TransactionPerson");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.TransactionTag", b =>
                {
                    b.Property<int>("TransactionId");

                    b.Property<int>("TagId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TransactionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TransactionTag");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.User", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.Transaction", b =>
                {
                    b.HasOne("MoneyManagerApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("MoneyManagerApi.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("MoneyManagerApi.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoneyManagerApi.Models.TransactionPerson", b =>
                {
                    b.HasOne("MoneyManagerApi.Models.Person", "Person")
                        .WithMany("TransactionPeople")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoneyManagerApi.Models.Transaction", "Transaction")
                        .WithMany("TransactionPeople")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyManagerApi.Models.TransactionTag", b =>
                {
                    b.HasOne("MoneyManagerApi.Models.Tag", "Tag")
                        .WithMany("TransactionTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoneyManagerApi.Models.Transaction", "Transaction")
                        .WithMany("TransactionTags")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
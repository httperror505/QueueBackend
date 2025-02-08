﻿// <auto-generated />
using System;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(QueueDbContext))]
    [Migration("20250207080736_CompletingTable")]
    partial class CompletingTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("TimeStamped")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Backend.Models.Counter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CurrentTicketId")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrentTicketId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Counters");
                });

            modelBuilder.Entity("Backend.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("CurrentTicketNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Backend.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Backend.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Backend.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Creation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long?>("NumberAssigned")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("StudentId")
                        .HasColumnType("text");

                    b.Property<int?>("TicketDocumentId")
                        .HasColumnType("integer");

                    b.Property<int?>("TicketFinanceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TicketDocumentId");

                    b.HasIndex("TicketFinanceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Backend.Models.TicketDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("AmountToPay")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("CashTendered")
                        .HasColumnType("numeric");

                    b.Property<string>("PurposeOfTransaction")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TicketDocuments");
                });

            modelBuilder.Entity("Backend.Models.TicketFinance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("TypeOfDocument")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfDocument");

                    b.ToTable("TicketFinances");
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TransactedBy")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TicketId");

                    b.HasIndex("TransactedBy");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Backend.Models.Account", b =>
                {
                    b.HasOne("Backend.Models.Department", "Department")
                        .WithMany("Accounts")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Backend.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Backend.Models.Counter", b =>
                {
                    b.HasOne("Backend.Models.Ticket", "CurrentTicket")
                        .WithMany("Counter")
                        .HasForeignKey("CurrentTicketId");

                    b.HasOne("Backend.Models.Department", "Department")
                        .WithMany("Counters")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("CurrentTicket");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Backend.Models.Document", b =>
                {
                    b.HasOne("Backend.Models.Department", "Department")
                        .WithMany("Documents")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Backend.Models.Ticket", b =>
                {
                    b.HasOne("Backend.Models.Department", "Department")
                        .WithMany("Tickets")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Backend.Models.TicketDocument", "TicketDocument")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketDocumentId");

                    b.HasOne("Backend.Models.TicketFinance", "TicketFinance")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketFinanceId");

                    b.Navigation("Department");

                    b.Navigation("TicketDocument");

                    b.Navigation("TicketFinance");
                });

            modelBuilder.Entity("Backend.Models.TicketFinance", b =>
                {
                    b.HasOne("Backend.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("TypeOfDocument");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.HasOne("Backend.Models.Department", "Department")
                        .WithMany("Transactions")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Backend.Models.Ticket", "Ticket")
                        .WithMany("Transaction")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Account", "Account")
                        .WithMany("Transaction")
                        .HasForeignKey("TransactedBy");

                    b.Navigation("Account");

                    b.Navigation("Department");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Backend.Models.Account", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Backend.Models.Department", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Counters");

                    b.Navigation("Documents");

                    b.Navigation("Tickets");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Backend.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Backend.Models.Ticket", b =>
                {
                    b.Navigation("Counter");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Backend.Models.TicketDocument", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Backend.Models.TicketFinance", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}

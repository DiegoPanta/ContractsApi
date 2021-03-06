﻿// <auto-generated />
using System;
using ContratosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContractsApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200427145036_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContratosApi.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnName("Banco")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Code")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("NumInstallments")
                        .HasColumnName("NumParcelas")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnName("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Contrato","pagamento");
                });

            modelBuilder.Entity("ContratosApi.Models.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractId")
                        .HasColumnName("IdContrato")
                        .HasColumnType("int");

                    b.Property<int>("NumInstallment")
                        .HasColumnName("NumParcela")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PayDay")
                        .HasColumnName("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnName("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Parcela","pagamento");
                });

            modelBuilder.Entity("ContratosApi.Models.Installment", b =>
                {
                    b.HasOne("ContratosApi.Models.Contract", "Contract")
                        .WithMany("Installments")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

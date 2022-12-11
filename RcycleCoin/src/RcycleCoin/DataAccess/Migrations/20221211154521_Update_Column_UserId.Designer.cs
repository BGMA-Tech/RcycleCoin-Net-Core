﻿// <auto-generated />
using System;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(RecycleCoinContext))]
    [Migration("20221211154521_Update_Column_UserId")]
    partial class Update_Column_UserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.RecycleProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RecycleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RecycleName");

                    b.Property<int>("RecyclePoint")
                        .HasColumnType("int")
                        .HasColumnName("RecyclePoint");

                    b.Property<int>("RecycleTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RecycleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RecycleTypeId");

                    b.ToTable("RecycleProduct", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.RecycleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RecycleTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RecycleTypeName");

                    b.HasKey("Id");

                    b.ToTable("RecycleType", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.UserRecycleProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("CreatedAt");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int>("RecycleProductId")
                        .HasColumnType("int")
                        .HasColumnName("RecycleProductId");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecycleProductId");

                    b.ToTable("UserRecycleProduct", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.RecycleProduct", b =>
                {
                    b.HasOne("Entities.Concrete.RecycleType", "RecycleType")
                        .WithMany()
                        .HasForeignKey("RecycleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecycleType");
                });

            modelBuilder.Entity("Entities.Concrete.UserRecycleProduct", b =>
                {
                    b.HasOne("Entities.Concrete.RecycleProduct", "RecycleProduct")
                        .WithMany()
                        .HasForeignKey("RecycleProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecycleProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
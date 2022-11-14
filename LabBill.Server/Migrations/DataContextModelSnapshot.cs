﻿// <auto-generated />
using System;
using LabBill.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabBill.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("LabBill.Shared.Model.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("LabBill.Shared.Model.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detail")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BillState = 0,
                            BillType = 0,
                            Brief = "测试1",
                            DateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "asaa",
                            Price = 10m
                        },
                        new
                        {
                            Id = 2,
                            BillState = 1,
                            BillType = 1,
                            Brief = "测试2",
                            DateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "asaa222",
                            Price = -100m
                        });
                });

            modelBuilder.Entity("LabBill.Shared.Model.BillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BillTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Detail = "",
                            Name = "食品"
                        },
                        new
                        {
                            Id = 2,
                            Detail = "",
                            Name = "设备"
                        },
                        new
                        {
                            Id = 3,
                            Detail = "",
                            Name = "娱乐"
                        },
                        new
                        {
                            Id = 4,
                            Detail = "",
                            Name = "知识"
                        },
                        new
                        {
                            Id = 5,
                            Detail = "",
                            Name = "工资"
                        },
                        new
                        {
                            Id = 6,
                            Detail = "",
                            Name = "其余"
                        });
                });

            modelBuilder.Entity("LabBill.Shared.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "randolf"
                        },
                        new
                        {
                            Id = 2,
                            Name = "pdd"
                        },
                        new
                        {
                            Id = 3,
                            Name = "张荣侨"
                        },
                        new
                        {
                            Id = 4,
                            Name = "YXY"
                        });
                });

            modelBuilder.Entity("LabBill.Shared.Model.Asset", b =>
                {
                    b.HasOne("LabBill.Shared.Model.Bill", null)
                        .WithMany("Assets")
                        .HasForeignKey("BillId");
                });

            modelBuilder.Entity("LabBill.Shared.Model.BillType", b =>
                {
                    b.HasOne("LabBill.Shared.Model.Bill", null)
                        .WithMany("BillTypes")
                        .HasForeignKey("BillId");
                });

            modelBuilder.Entity("LabBill.Shared.Model.Person", b =>
                {
                    b.HasOne("LabBill.Shared.Model.Bill", null)
                        .WithMany("Persons")
                        .HasForeignKey("BillId");
                });

            modelBuilder.Entity("LabBill.Shared.Model.Bill", b =>
                {
                    b.Navigation("Assets");

                    b.Navigation("BillTypes");

                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaStoreDbContext))]
    [Migration("20201029221424_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaStore.Domain.Models.Menu.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsTopping")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsTopping = false,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            IsTopping = true,
                            Name = "PizzaTopping"
                        },
                        new
                        {
                            Id = 3,
                            IsTopping = false,
                            Name = "MainMeal"
                        },
                        new
                        {
                            Id = 4,
                            IsTopping = true,
                            Name = "MainMealTopping"
                        },
                        new
                        {
                            Id = 5,
                            IsTopping = false,
                            Name = "Soup"
                        },
                        new
                        {
                            Id = 6,
                            IsTopping = false,
                            Name = "Drink"
                        });
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.Menu.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TaxId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 1,
                            Name = "Margherita",
                            Price = 20m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 2,
                            GroupId = 1,
                            Name = "Vegetariana",
                            Price = 22m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 3,
                            GroupId = 1,
                            Name = "Tosca",
                            Price = 25m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 4,
                            GroupId = 1,
                            Name = "Venecia",
                            Price = 25m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 5,
                            GroupId = 2,
                            Name = "Double cheese",
                            Price = 2m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 6,
                            GroupId = 2,
                            Name = "Salami",
                            Price = 2m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 7,
                            GroupId = 2,
                            Name = "Ham",
                            Price = 2m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 8,
                            GroupId = 2,
                            Name = "Mushrooms",
                            Price = 2m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 9,
                            GroupId = 3,
                            Name = "Pork chop with chips / rice / potatoes",
                            Price = 30m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 10,
                            GroupId = 3,
                            Name = "Fish and chips",
                            Price = 28m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 11,
                            GroupId = 3,
                            Name = "Hungarian style potato pancake",
                            Price = 27m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 12,
                            GroupId = 4,
                            Name = "Salad bar",
                            Price = 5m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 13,
                            GroupId = 4,
                            Name = "Set of sauces",
                            Price = 6m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 14,
                            GroupId = 5,
                            Name = "Tomato soup",
                            Price = 12m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 15,
                            GroupId = 5,
                            Name = "Chicken soup",
                            Price = 10m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 16,
                            GroupId = 6,
                            Name = "Coffee",
                            Price = 5m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 17,
                            GroupId = 6,
                            Name = "Tea",
                            Price = 5m,
                            TaxId = 1
                        },
                        new
                        {
                            Id = 18,
                            GroupId = 6,
                            Name = "Coke",
                            Price = 5m,
                            TaxId = 1
                        });
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.Menu.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Taxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "basicTax",
                            Value = 23
                        });
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.Menu.Product", b =>
                {
                    b.HasOne("PizzaStore.Domain.Models.Menu.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Domain.Models.Menu.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("PizzaStore.Domain.Models.OrderAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HouseUnitNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("PizzaStore.Domain.Models.OrderAggregate.Customer", "Customer", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });

            modelBuilder.Entity("PizzaStore.Domain.Models.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("PizzaStore.Domain.Models.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}

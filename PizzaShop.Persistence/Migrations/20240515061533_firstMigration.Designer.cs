﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PizzaShop.Persistence.Context;

#nullable disable

namespace PizzaShop.Persistence.Migrations
{
    [DbContext(typeof(PizzaShopDBContext))]
    [Migration("20240515061533_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PizzaShop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Traditional"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vegetarian"
                        },
                        new
                        {
                            Id = 3,
                            Name = "MeatLovers"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Seafood"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hawaiian"
                        },
                        new
                        {
                            Id = 6,
                            Name = "BBQ"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Margherita"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 9,
                            Name = "FourCheese"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Supreme"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Farmhouse"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Calzone"
                        },
                        new
                        {
                            Id = 14,
                            Name = "GlutenFree"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Custom"
                        });
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Base",
                            Price = 0m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Topping",
                            Price = 0m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sauce",
                            Price = 0m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cheese",
                            Price = 0m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Vegetable",
                            Price = 0m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Meat",
                            Price = 0m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Seafood",
                            Price = 0m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Herb",
                            Price = 0m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Fruit",
                            Price = 0m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Nut",
                            Price = 0m
                        },
                        new
                        {
                            Id = 11,
                            Name = "Dairy",
                            Price = 0m
                        },
                        new
                        {
                            Id = 12,
                            Name = "Grain",
                            Price = 0m
                        },
                        new
                        {
                            Id = 13,
                            Name = "Condiment",
                            Price = 0m
                        },
                        new
                        {
                            Id = 14,
                            Name = "Oil",
                            Price = 0m
                        },
                        new
                        {
                            Id = 15,
                            Name = "Sweetener",
                            Price = 0m
                        },
                        new
                        {
                            Id = 16,
                            Name = "Other",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("CategoryId1")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SizeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("SizeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.PizzaIngredients", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer");

                    b.HasKey("IngredientId", "PizzaId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredients");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Size");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Order", b =>
                {
                    b.HasOne("PizzaShop.Domain.Entities.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaShop.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Pizza", b =>
                {
                    b.HasOne("PizzaShop.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaShop.Domain.Entities.Category", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId1");

                    b.HasOne("PizzaShop.Domain.Entities.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.PizzaIngredients", b =>
                {
                    b.HasOne("PizzaShop.Domain.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaShop.Domain.Entities.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.User", b =>
                {
                    b.HasOne("PizzaShop.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Category", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PizzaShop.Domain.Entities.Size", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}

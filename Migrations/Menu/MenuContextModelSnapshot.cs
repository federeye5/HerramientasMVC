﻿// <auto-generated />
using Clase4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clase4.Migrations.Menu
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Clase4.Models.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calories")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Clase4.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Phone")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("MenuRestaurant", b =>
                {
                    b.Property<int>("Menusid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Restaurantsid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Menusid", "Restaurantsid");

                    b.HasIndex("Restaurantsid");

                    b.ToTable("MenuRestaurant");
                });

            modelBuilder.Entity("MenuRestaurant", b =>
                {
                    b.HasOne("Clase4.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("Menusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clase4.Models.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("Restaurantsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

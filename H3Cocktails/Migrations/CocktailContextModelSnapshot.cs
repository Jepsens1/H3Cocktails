﻿// <auto-generated />
using H3Cocktails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H3Cocktails.Migrations
{
    [DbContext(typeof(CocktailContext))]
    partial class CocktailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("H3Cocktails.Models.Drink", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("H3Cocktails.Models.Ingrediens", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("DrinkName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("DrinkName");

                    b.ToTable("Ingrediens");
                });

            modelBuilder.Entity("H3Cocktails.Models.Ingrediens", b =>
                {
                    b.HasOne("H3Cocktails.Models.Drink", null)
                        .WithMany("Ingrediens")
                        .HasForeignKey("DrinkName");
                });

            modelBuilder.Entity("H3Cocktails.Models.Drink", b =>
                {
                    b.Navigation("Ingrediens");
                });
#pragma warning restore 612, 618
        }
    }
}

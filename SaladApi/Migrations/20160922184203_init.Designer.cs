using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SaladApi.Repository;

namespace SaladApi.Migrations
{
    [DbContext(typeof(SaladApiDbContext))]
    [Migration("20160922184203_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SaladApi.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("SaladApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int?>("DrinkId")
                        .IsRequired();

                    b.Property<int?>("SaladId")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("SaladId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SaladApi.Models.Salad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ingredients")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Salads");
                });

            modelBuilder.Entity("SaladApi.Models.Order", b =>
                {
                    b.HasOne("SaladApi.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaladApi.Models.Salad", "Salad")
                        .WithMany()
                        .HasForeignKey("SaladId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

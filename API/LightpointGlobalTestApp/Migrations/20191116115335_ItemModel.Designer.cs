﻿// <auto-generated />
using System;
using LightpointGlobalTestApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LightpointGlobalTestApp.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20191116115335_ItemModel")]
    partial class ItemModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LightpointGlobalTestApp.Model.DatabaseModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdateAt");

                    b.Property<string>("Name");

                    b.Property<int>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LightpointGlobalTestApp.Model.DatabaseModels.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreateAt");

                    b.Property<DateTime>("LastUpdateAt");

                    b.Property<string>("Name");

                    b.Property<string>("WorkingHours");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("LightpointGlobalTestApp.Model.DatabaseModels.Item", b =>
                {
                    b.HasOne("LightpointGlobalTestApp.Model.DatabaseModels.Shop", "Shop")
                        .WithMany("Items")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using EluneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EluneApi.Migrations
{
    [DbContext(typeof(EluneApiContext))]
    partial class EluneApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EluneApi.Models.Baby", b =>
                {
                    b.Property<int>("BabyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BabyId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BabyId");

                    b.ToTable("Babies");

                    b.HasData(
                        new
                        {
                            BabyId = 1,
                            BirthDate = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Stewie Griffin"
                        },
                        new
                        {
                            BabyId = 2,
                            BirthDate = new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Maggie Simpson"
                        },
                        new
                        {
                            BabyId = 3,
                            BirthDate = new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Tommy Pickles"
                        },
                        new
                        {
                            BabyId = 4,
                            BirthDate = new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Baby Groot"
                        },
                        new
                        {
                            BabyId = 5,
                            BirthDate = new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Scrappy Doo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

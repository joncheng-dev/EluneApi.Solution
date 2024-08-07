﻿// <auto-generated />
using System;
using EluneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EluneApi.Migrations
{
    [DbContext(typeof(EluneApiContext))]
    [Migration("20240707094409_UpdateModelElapsedTime")]
    partial class UpdateModelElapsedTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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

            modelBuilder.Entity("EluneApi.Models.SleepTime", b =>
                {
                    b.Property<int>("SleepTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SleepTimeId"));

                    b.Property<int>("BabyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SleepTimeId");

                    b.HasIndex("BabyId");

                    b.ToTable("SleepTimes");

                    b.HasData(
                        new
                        {
                            SleepTimeId = 1,
                            BabyId = 1,
                            EndTime = new DateTime(2024, 7, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 1, 20, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            SleepTimeId = 2,
                            BabyId = 1,
                            EndTime = new DateTime(2024, 7, 3, 6, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 2, 21, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            SleepTimeId = 3,
                            BabyId = 2,
                            EndTime = new DateTime(2024, 7, 4, 6, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 3, 22, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            SleepTimeId = 4,
                            BabyId = 3,
                            EndTime = new DateTime(2024, 7, 3, 4, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 2, 19, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            SleepTimeId = 5,
                            BabyId = 4,
                            EndTime = new DateTime(2024, 7, 3, 7, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 2, 23, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            SleepTimeId = 6,
                            BabyId = 5,
                            EndTime = new DateTime(2024, 7, 3, 8, 0, 0, 0, DateTimeKind.Utc),
                            StartTime = new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("EluneApi.Models.SleepTime", b =>
                {
                    b.HasOne("EluneApi.Models.Baby", "Baby")
                        .WithMany("SleepTimes")
                        .HasForeignKey("BabyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Baby");
                });

            modelBuilder.Entity("EluneApi.Models.Baby", b =>
                {
                    b.Navigation("SleepTimes");
                });
#pragma warning restore 612, 618
        }
    }
}

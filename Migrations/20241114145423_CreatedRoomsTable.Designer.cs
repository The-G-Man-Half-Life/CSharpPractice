﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticeC_.Data;

#nullable disable

namespace PracticeC_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241114145423_CreatedRoomsTable")]
    partial class CreatedRoomsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PracticeC_.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identification_number");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("PracticeC_.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Availability")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("availability");

                    b.Property<byte>("MaxOccupancyPeople")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("max_occupancy_people");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("double")
                        .HasColumnName("price_per_night");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("room_number");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PracticeC_.Models.Room_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Room_types");
                });

            modelBuilder.Entity("PracticeC_.Models.Room", b =>
                {
                    b.HasOne("PracticeC_.Models.Room_type", "Room_Type")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room_Type");
                });
#pragma warning restore 612, 618
        }
    }
}

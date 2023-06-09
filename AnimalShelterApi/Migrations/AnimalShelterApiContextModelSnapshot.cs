﻿// <auto-generated />
using System;
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimaShelterApi.Migrations
{
    [DbContext(typeof(AnimalShelterApiContext))]
    partial class AnimalShelterApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalShelterApi.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateAdmitted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Available = true,
                            Breed = "Scruffy",
                            DateAdmitted = new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Scratchy",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 2,
                            Available = true,
                            Breed = "Beagle/Sneaky",
                            DateAdmitted = new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cranko",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 3,
                            Available = false,
                            Breed = "Feathered",
                            DateAdmitted = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sporty",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalId = 4,
                            Available = true,
                            Breed = "Foxhound",
                            DateAdmitted = new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Stanley",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalId = 5,
                            Available = true,
                            Breed = "Tabby/Stinky",
                            DateAdmitted = new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Borgus",
                            Type = "Cat"
                        });
                });

            modelBuilder.Entity("AnimalShelterApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("GivenName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EmailAddress = "gogo@rob.com",
                            GivenName = "Gogo",
                            Password = "eggs",
                            Role = "Adminstrator",
                            Surname = "Robinson",
                            Username = "gogorobinson"
                        },
                        new
                        {
                            UserId = 2,
                            EmailAddress = "stever@rob.com",
                            GivenName = "Stever",
                            Password = "eggs2",
                            Role = "Standard",
                            Surname = "Scorpion",
                            Username = "stever"
                        },
                        new
                        {
                            UserId = 3,
                            EmailAddress = "dread@rob.com",
                            GivenName = "Dread",
                            Password = "eggs3",
                            Role = "Standard",
                            Surname = "Veil",
                            Username = "dread"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

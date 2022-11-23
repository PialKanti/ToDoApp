﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Data;

#nullable disable

namespace ToDoApp.Migrations
{
    [DbContext(typeof(ToDoContext))]
    partial class ToDoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApp.Entities.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7311),
                            Description = "This is Task 1.",
                            ExpiryDateTime = new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task 1",
                            Place = "Dhaka"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7322),
                            Description = "This is Task 2.",
                            ExpiryDateTime = new DateTime(2022, 11, 22, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task 2",
                            Place = "Dhaka"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7323),
                            Description = "This is Task 2.",
                            ExpiryDateTime = new DateTime(2022, 11, 22, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task 3",
                            Place = "Khulna"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

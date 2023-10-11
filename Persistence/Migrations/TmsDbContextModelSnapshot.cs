﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(TmsDbContext))]
    partial class TmsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.TMS.TaskEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BODY_PATH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CREATED_UTC_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DUE_UTC_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("LEVEL")
                        .HasColumnType("int");

                    b.Property<int>("REQUESTOR")
                        .HasColumnType("int");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("UPDATED_UTC_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TASK");
                });

            modelBuilder.Entity("Domain.Entities.TMS.TaskFileEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CREATED_UTC_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("FILE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PATH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TASK_REF")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("TASK_FILE");
                });

            modelBuilder.Entity("Domain.Entities.TMS.UserTaskEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CREATED_UTC_DATE")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TASK_REF")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("USER_REF")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TASK_USERS");
                });
#pragma warning restore 612, 618
        }
    }
}

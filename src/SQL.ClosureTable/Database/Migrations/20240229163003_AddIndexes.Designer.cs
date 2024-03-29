﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQL.ClosureTable.Database;

#nullable disable

namespace SQL.ClosureTable.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240229163003_AddIndexes")]
    partial class AddIndexes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SQL.ClosureTable.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "root"
                        });
                });

            modelBuilder.Entity("SQL.ClosureTable.Models.OrganizationClosure", b =>
                {
                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("NodeId", "ParentId");

                    b.HasIndex("NodeId");

                    b.HasIndex("ParentId");

                    b.ToTable("OrganizationClosures");
                });

            modelBuilder.Entity("SQL.ClosureTable.Models.OrganizationClosure", b =>
                {
                    b.HasOne("SQL.ClosureTable.Models.Organization", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SQL.ClosureTable.Models.Organization", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("Parent");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Infra.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220915151736_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infra.EntityFrameworkCore.Entities.BasicInformation", b =>
                {
                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("UserInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.ToTable("BasicInformation", (string)null);
                });

            modelBuilder.Entity("Infra.EntityFrameworkCore.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("Infra.EntityFrameworkCore.Entities.BasicInformation", b =>
                {
                    b.HasOne("Infra.EntityFrameworkCore.Entities.Request", null)
                        .WithOne("BasicInformation")
                        .HasForeignKey("Infra.EntityFrameworkCore.Entities.BasicInformation", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infra.EntityFrameworkCore.Entities.Request", b =>
                {
                    b.Navigation("BasicInformation");
                });
#pragma warning restore 612, 618
        }
    }
}

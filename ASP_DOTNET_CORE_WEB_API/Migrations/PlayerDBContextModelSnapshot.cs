﻿// <auto-generated />
using System;
using ASP_DOTNET_CORE_WEB_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP_DOTNET_CORE_WEB_API.Migrations
{
    [DbContext(typeof(PlayerDBContext))]
    partial class PlayerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP_DOTNET_CORE_WEB_API.Models.Domain.AccountData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonalDataID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerDataID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDataID");

                    b.HasIndex("PlayerDataID");

                    b.ToTable("AccountDatas");
                });

            modelBuilder.Entity("ASP_DOTNET_CORE_WEB_API.Models.Domain.ImageData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ImageSize")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("imageDatas");
                });

            modelBuilder.Entity("ASP_DOTNET_CORE_WEB_API.Models.Domain.PersonalData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("ASP_DOTNET_CORE_WEB_API.Models.Domain.PlayerData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Exp")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayerDatas");
                });

            modelBuilder.Entity("ASP_DOTNET_CORE_WEB_API.Models.Domain.AccountData", b =>
                {
                    b.HasOne("ASP_DOTNET_CORE_WEB_API.Models.Domain.PersonalData", "PersonalData")
                        .WithMany()
                        .HasForeignKey("PersonalDataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP_DOTNET_CORE_WEB_API.Models.Domain.PlayerData", "PlayerData")
                        .WithMany()
                        .HasForeignKey("PlayerDataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalData");

                    b.Navigation("PlayerData");
                });
#pragma warning restore 612, 618
        }
    }
}

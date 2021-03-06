﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteMeasure.Data;

namespace SiteMeasure.Data.Migrations
{
    [DbContext(typeof(SiteMeasureDbContext))]
    [Migration("20200715080924_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiteMeasure.Core.Entities.RequestedUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestedUrls");
                });

            modelBuilder.Entity("SiteMeasure.Core.Entities.Sitemap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestedUrlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SitemapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestedUrlId");

                    b.ToTable("Sitemaps");
                });

            modelBuilder.Entity("SiteMeasure.Core.Entities.SitemapMeasure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SitemapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("SitemapId");

                    b.ToTable("SitemapMeasures");
                });

            modelBuilder.Entity("SiteMeasure.Core.Entities.Sitemap", b =>
                {
                    b.HasOne("SiteMeasure.Core.Entities.RequestedUrl", "RequestedUrl")
                        .WithMany("SitemapUrls")
                        .HasForeignKey("RequestedUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SiteMeasure.Core.Entities.SitemapMeasure", b =>
                {
                    b.HasOne("SiteMeasure.Core.Entities.Sitemap", "Sitemap")
                        .WithMany("Measurements")
                        .HasForeignKey("SitemapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

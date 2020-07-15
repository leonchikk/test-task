using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteMeasure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestedUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sitemaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SitemapUrl = table.Column<string>(nullable: true),
                    RequestedUrlId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitemaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sitemaps_RequestedUrls_RequestedUrlId",
                        column: x => x.RequestedUrlId,
                        principalTable: "RequestedUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SitemapMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeSpan = table.Column<TimeSpan>(nullable: false),
                    SitemapId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitemapMeasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitemapMeasures_Sitemaps_SitemapId",
                        column: x => x.SitemapId,
                        principalTable: "Sitemaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SitemapMeasures_SitemapId",
                table: "SitemapMeasures",
                column: "SitemapId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitemaps_RequestedUrlId",
                table: "Sitemaps",
                column: "RequestedUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SitemapMeasures");

            migrationBuilder.DropTable(
                name: "Sitemaps");

            migrationBuilder.DropTable(
                name: "RequestedUrls");
        }
    }
}

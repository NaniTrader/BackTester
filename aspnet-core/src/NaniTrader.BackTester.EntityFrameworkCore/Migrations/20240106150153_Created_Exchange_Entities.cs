using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaniTrader.BackTester.Migrations
{
    /// <inheritdoc />
    public partial class Created_Exchange_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Exch");

            migrationBuilder.CreateTable(
                name: "NaniExchanges",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaniEquityFutureSecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniEquityFutureSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniEquityFutureSecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaniEquityOptionSecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniEquityOptionSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniEquityOptionSecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaniEquitySecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniEquitySecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniEquitySecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaniIndexFutureSecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniIndexFutureSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniIndexFutureSecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaniIndexOptionSecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniIndexOptionSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniIndexOptionSecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaniIndexSecurities",
                schema: "Exch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaniIndexSecurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaniIndexSecurities_NaniExchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalSchema: "Exch",
                        principalTable: "NaniExchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaniEquityFutureSecurities_ExchangeId",
                schema: "Exch",
                table: "NaniEquityFutureSecurities",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaniEquityOptionSecurities_ExchangeId",
                schema: "Exch",
                table: "NaniEquityOptionSecurities",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaniEquitySecurities_ExchangeId",
                schema: "Exch",
                table: "NaniEquitySecurities",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaniIndexFutureSecurities_ExchangeId",
                schema: "Exch",
                table: "NaniIndexFutureSecurities",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaniIndexOptionSecurities_ExchangeId",
                schema: "Exch",
                table: "NaniIndexOptionSecurities",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaniIndexSecurities_ExchangeId",
                schema: "Exch",
                table: "NaniIndexSecurities",
                column: "ExchangeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaniEquityFutureSecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniEquityOptionSecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniEquitySecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniIndexFutureSecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniIndexOptionSecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniIndexSecurities",
                schema: "Exch");

            migrationBuilder.DropTable(
                name: "NaniExchanges",
                schema: "Exch");
        }
    }
}

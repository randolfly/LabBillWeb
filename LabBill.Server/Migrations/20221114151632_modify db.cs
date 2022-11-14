using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabBill.Server.Migrations
{
    /// <inheritdoc />
    public partial class modifydb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Brief = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    BillState = table.Column<int>(type: "INTEGER", nullable: false),
                    BillType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Detail = table.Column<string>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillTypes_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BillTypes",
                columns: new[] { "Id", "BillId", "Detail", "Name" },
                values: new object[,]
                {
                    { 1, null, "", "食品" },
                    { 2, null, "", "设备" },
                    { 3, null, "", "娱乐" },
                    { 4, null, "", "知识" },
                    { 5, null, "", "工资" },
                    { 6, null, "", "其余" }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "BillState", "BillType", "Brief", "DateTime", "Detail", "Price" },
                values: new object[,]
                {
                    { 1, 0, 0, "测试1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asaa", 10m },
                    { 2, 1, 1, "测试2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asaa222", -100m }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BillId", "Name" },
                values: new object[,]
                {
                    { 1, null, "randolf" },
                    { 2, null, "pdd" },
                    { 3, null, "张荣侨" },
                    { 4, null, "YXY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BillId",
                table: "Assets",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillTypes_BillId",
                table: "BillTypes",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BillId",
                table: "Persons",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "BillTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}

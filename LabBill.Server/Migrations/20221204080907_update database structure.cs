using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabBill.Server.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "BillPersons");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "Assets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "BillPerson",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPerson", x => new { x.BillId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_BillPerson_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillPerson_PersonId",
                table: "BillPerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "BillPerson");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BillPersons",
                columns: table => new
                {
                    BillsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPersons", x => new { x.BillsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_BillPersons_Bills_BillsId",
                        column: x => x.BillsId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillPersons_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillPersons_PersonsId",
                table: "BillPersons",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

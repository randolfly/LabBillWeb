using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabBill.Server.Migrations
{
    /// <inheritdoc />
    public partial class 修改数据可以 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Bills_BillId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BillId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Bills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "BillPerson");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Persons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Bills",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "Assets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "BillId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "BillId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                column: "BillId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "BillId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BillId",
                table: "Persons",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Bills_BillId",
                table: "Assets",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Bills_BillId",
                table: "Persons",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabBill.Server.Migrations
{
    /// <inheritdoc />
    public partial class addbillpersonentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPerson_Bills_BillId",
                table: "BillPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_BillPerson_Persons_PersonId",
                table: "BillPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillPerson",
                table: "BillPerson");

            migrationBuilder.RenameTable(
                name: "BillPerson",
                newName: "BillPersons");

            migrationBuilder.RenameIndex(
                name: "IX_BillPerson_PersonId",
                table: "BillPersons",
                newName: "IX_BillPersons_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillPersons",
                table: "BillPersons",
                columns: new[] { "BillId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillPersons_Bills_BillId",
                table: "BillPersons",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillPersons_Persons_PersonId",
                table: "BillPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPersons_Bills_BillId",
                table: "BillPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_BillPersons_Persons_PersonId",
                table: "BillPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillPersons",
                table: "BillPersons");

            migrationBuilder.RenameTable(
                name: "BillPersons",
                newName: "BillPerson");

            migrationBuilder.RenameIndex(
                name: "IX_BillPersons_PersonId",
                table: "BillPerson",
                newName: "IX_BillPerson_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillPerson",
                table: "BillPerson",
                columns: new[] { "BillId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillPerson_Bills_BillId",
                table: "BillPerson",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillPerson_Persons_PersonId",
                table: "BillPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

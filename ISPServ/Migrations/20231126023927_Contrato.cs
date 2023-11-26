using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISPServ.Migrations
{
    /// <inheritdoc />
    public partial class Contrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContratoId",
                table: "Conexoes",
                type: "VARCHAR(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataInativação",
                table: "Conexoes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    DataAtivacao = table.Column<DateOnly>(type: "DATE", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "DATE", nullable: false),
                    IsAtivo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conexoes_ContratoId",
                table: "Conexoes",
                column: "ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conexoes_Contratos_ContratoId",
                table: "Conexoes",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conexoes_Contratos_ContratoId",
                table: "Conexoes");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Conexoes_ContratoId",
                table: "Conexoes");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "Conexoes");

            migrationBuilder.DropColumn(
                name: "DataInativação",
                table: "Conexoes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISPServ.Migrations
{
    /// <inheritdoc />
    public partial class ClienteDataInativacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DataInativacao",
                table: "Clientes",
                type: "DATE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "Clientes");
        }
    }
}

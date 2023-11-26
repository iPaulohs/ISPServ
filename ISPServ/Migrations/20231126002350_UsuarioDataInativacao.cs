using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISPServ.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioDataInativacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DataInativacao",
                table: "AspNetUsers",
                type: "DATE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacPay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AttDaConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Clientes",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "Documento");
        }
    }
}

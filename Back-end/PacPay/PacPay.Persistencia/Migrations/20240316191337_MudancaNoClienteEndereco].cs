using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacPay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNoClienteEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PontoDeReferencia",
                table: "Enderecos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontoDeReferencia",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Clientes");
        }
    }
}

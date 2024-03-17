using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacPay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CampoDeDescricaoNaOperacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Operacoes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Operacoes");
        }
    }
}

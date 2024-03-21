using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacPay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ConvertendoColunaAtivaParaBit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativa",
                table: "Contas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ativa",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

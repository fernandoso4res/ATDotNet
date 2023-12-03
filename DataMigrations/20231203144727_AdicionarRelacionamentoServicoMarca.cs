using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanGrassAppWeb.Data.Migrations
{
    public partial class AdicionarRelacionamentoServicoMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "TBL_SERVICO",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SERVICO_MarcaId",
                table: "TBL_SERVICO",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_SERVICO_Marca_MarcaId",
                table: "TBL_SERVICO",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_SERVICO_Marca_MarcaId",
                table: "TBL_SERVICO");

            migrationBuilder.DropIndex(
                name: "IX_TBL_SERVICO_MarcaId",
                table: "TBL_SERVICO");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "TBL_SERVICO");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanGrassAppWeb.DataMigrations
{
    public partial class AdicionarRelacionamentoServicoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaServico",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaServico", x => new { x.CategoriasCategoriaId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_CategoriaServico_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaServico_TBL_SERVICO_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "TBL_SERVICO",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaServico_ServicosServicoId",
                table: "CategoriaServico",
                column: "ServicosServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaServico");
        }
    }
}

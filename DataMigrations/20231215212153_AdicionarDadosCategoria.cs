using CleanGrassAppWeb.Data;
using CleanGrassAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanGrassAppWeb.DataMigrations
{
    public partial class AdicionarDadosCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new CleanGrassDbContext();
            context.Categoria.AddRange(ObterCargaInicialCategoria());
            context.SaveChanges();
        }

        private IList<Categoria> ObterCargaInicialCategoria()
        {
            return new List<Categoria>()
            {
                new Categoria() { Descricao = "Jardinagem" },
                new Categoria() { Descricao = "Paisagismo" },
                new Categoria() { Descricao = "Terraplanagem" }
            };
        }

        
    }
}

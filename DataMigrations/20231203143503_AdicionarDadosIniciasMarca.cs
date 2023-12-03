using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Data;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanGrassAppWeb.DataMigrations
{
    public partial class AdicionarDadosIniciasMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new CleanGrassDbContext();
            context.Marca.AddRange(ObterCargaInicialMarca());
            context.SaveChanges();
        }

        private IList<Marca> ObterCargaInicialMarca()
        {
            return new List<Marca>()
            {
                new Marca() { Descricao = "Empresa do João" },
                new Marca() { Descricao = "Empresa do Valmor" },
                new Marca() { Descricao = "Empresa do Antônio" }
            };
        }
    }
}

using CleanGrassAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanGrassAppWeb.Data.Migrations
{
    public partial class AdicionarDadosIniciaisServicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new CleanGrassDbContext();
            context.Servico.AddRange(ObterCargaInicialServico());
            context.SaveChanges();
        }

        private IList<Servico> ObterCargaInicialServico()
        {
            return new List<Servico>
            {
                new()
                {
                    Nome = "Roçada",
                    Descricao = "Corte profissional de grama para jardins impecáveis!",
                    ImagemUri = "/images/motorsense.jpeg",
                    Preco = 30.00,
                    DataCadastro = DateTime.Now,
                    JardineiroProfissional = false
                },
                new()
                {
                    Nome = "Podas",
                    Descricao = "Poda expert para jardins exuberantes!",
                    ImagemUri = "/images/motorsense.jpeg",
                    Preco = 16.00,
                    DataCadastro = DateTime.Now,
                    JardineiroProfissional = true
                },
                new()
                {
                    Nome = "Paisagismo",
                    Descricao = "Transforme seu espaço com paisagismo perfeito!",
                    ImagemUri = "/images/motorsense.jpeg",
                    Preco = 40.00,
                    DataCadastro = DateTime.Now,
                    JardineiroProfissional = true
                }
            };
        }

    }
}

namespace CleanGrassAppWeb.Models;

public class Marca
{
    public int MarcaId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Servico>? Servicos { get; set; }
}

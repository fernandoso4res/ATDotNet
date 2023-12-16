namespace CleanGrassAppWeb.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Descricao { get; set; } 
    public ICollection<Servico>? Servicos { get; set; }
}
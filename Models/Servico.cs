using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanGrassAppWeb.Models;

[Table("TBL_SERVICO")]
public class Servico
{
    [Key] public int ServicoId { get; set; }


    [Required(ErrorMessage = "Campo 'Nome' obrigatório")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo 'Nome' deve ter entre 5 e 50 caracteres")]
    public string Nome { get; set; }

    public string NomeSlug => Nome.ToLower().Replace(" ", "-");


    [Required(ErrorMessage = "Campo 'Descrição' obrigatório")]
    [Display(Name = "Descrição")]
    [StringLength(100, MinimumLength = 20, ErrorMessage = "Campo 'Descrição' deve ter entre 20 e 100 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo 'Caminho URL da imagem' obrigatório")]
    [Display(Name = "Caminho URL da imagem")]
    public string ImagemUri { get; set; }

    [Required(ErrorMessage = "Campo 'Preço' obrigatório")]
    [Display(Name = "Preço")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [DisplayFormat(DataFormatString = "{0:MMMM \\de yyyy}")]
    [Required(ErrorMessage = "Campo 'Disponível em' obrigatório")]
    [Display(Name = "Disponível em")]
    [DataType("month")]
    public DateTime DataCadastro { get; set; }

    public bool JardineiroProfissional { get; set; }

    [Display(Name = "Jardineiro Profissional")]
    public string JardineiroProfissionalFormatado => JardineiroProfissional ? "Sim" : "Não";
    
    [Display(Name = "Marca")]
    public int? MarcaId { get; set; }

    public ICollection<Categoria>? Categorias { get; set; }
}
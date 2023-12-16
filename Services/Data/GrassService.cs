using CleanGrassAppWeb.Data;
using CleanGrassAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanGrassAppWeb.Services.Data;

public class GrassService : IGrassService
{
    public CleanGrassDbContext _context { get; set; }
    
    public GrassService(CleanGrassDbContext context)
    {
        _context = context;
    }
    public void Alterar(Servico servico)
    {
        var servicoEncontrado = Obter(servico.ServicoId);
        servicoEncontrado.Nome = servico.Nome;
        servicoEncontrado.Descricao = servico.Descricao;
        servicoEncontrado.ImagemUri = servico.ImagemUri;
        servicoEncontrado.Preco = servico.Preco;
        servicoEncontrado.DataCadastro = servico.DataCadastro;
        servicoEncontrado.JardineiroProfissional = servico.JardineiroProfissional;
        servicoEncontrado.MarcaId = servico.MarcaId;
        servicoEncontrado.Categorias = servico.Categorias;
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var servicoEncontrado = Obter(id);
        _context.Servico.Remove(servicoEncontrado);
        _context.SaveChanges();
    }

    public void Incluir(Servico servico)
    {
        _context.Servico.Add(servico);
        _context.SaveChanges();
    }

    public Servico Obter(int id)
    {
        return _context.Servico
            .Include((item => item.Categorias))
            .SingleOrDefault(item => item.ServicoId == id);
        
    }

    public IList<Servico> ObterTodos()
    {
        return _context.Servico.ToList();
    }

    public IList<Marca> ObterTodasMarcas() => _context.Marca.ToList();
    public Marca ObterMarca(int id) => _context.Marca.SingleOrDefault(item => item.MarcaId == id);

    public IList<Categoria> ObterTodasCategorias() => _context.Categoria.ToList();
}
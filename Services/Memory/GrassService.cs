using CleanGrassAppWeb.Models;

namespace CleanGrassAppWeb.Services.Memory;

public class GrassService : IGrassService
{
    private IList<Servico> _servicos;

    public GrassService()
    {
        CarregarListaInicial();
    }

    public IList<Servico> ObterTodos()
    {
        return _servicos;
    }

    public Servico Obter(int id)
    {
        return ObterTodos().SingleOrDefault(item => item.ServicoId == id);
    }

    public void Incluir(Servico servico)
    {
        var proximoId = _servicos.Max(item => item.ServicoId) + 1;
        servico.ServicoId = proximoId;
        _servicos.Add(servico);
    }


    public void Alterar(Servico servico)
    {
        var servicoEncontrado = _servicos.SingleOrDefault(item => item.ServicoId == servico.ServicoId);
        servicoEncontrado.Nome = servico.Nome;
        servicoEncontrado.Descricao = servico.Descricao;
        servicoEncontrado.ImagemUri = servico.ImagemUri;
        servicoEncontrado.Preco = servico.Preco;
        servicoEncontrado.DataCadastro = servico.DataCadastro;
        servicoEncontrado.JardineiroProfissional = servico.JardineiroProfissional;
    }

    public void Excluir(int id)
    {
        var servicoEncontrado = Obter(id);
        _servicos.Remove(servicoEncontrado);
    }

    public IList<Marca> ObterTodasMarcas()
    {
        throw new NotImplementedException();
    }

    public Marca ObterMarca(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Categoria> ObterTodasCategorias()
    {
        throw new NotImplementedException();
    }

    private void CarregarListaInicial()
    {
        _servicos = new List<Servico>
        {
            new()
            {
                ServicoId = 1,
                Nome = "Roçada",
                Descricao = "Corte profissional de grama para jardins impecáveis!",
                ImagemUri = "/images/motorsense.jpeg",
                Preco = 30.00,
                DataCadastro = DateTime.Now,
                JardineiroProfissional = false
            },
            new()
            {
                ServicoId = 2,
                Nome = "Podas",
                Descricao = "Poda expert para jardins exuberantes!",
                ImagemUri = "/images/motorsense.jpeg",
                Preco = 16.00,
                DataCadastro = DateTime.Now,
                JardineiroProfissional = true
            },
            new()
            {
                ServicoId = 3,
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
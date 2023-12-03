using CleanGrassAppWeb.Models;

namespace CleanGrassAppWeb.Services;

public interface IGrassService
{
    IList<Servico> ObterTodos();
    Servico Obter(int id);
    void Incluir(Servico servico);
    void Alterar(Servico servico);
    void Excluir(int id);
    IList<Marca> ObterTodasMarcas();
    Marca ObterMarca(int id);
}
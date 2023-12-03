using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanGrassAppWeb.Pages;

public class IndexModel : PageModel
{
    private IGrassService _service;

    public IndexModel(IGrassService serivce, IConfiguration configuration)
    {
        _service = serivce;
    }

    public IList<Servico> ListaServico { get; private set; }

    public void OnGet()
    {
        ViewData["Title"] = "Página Inicial";

        ListaServico = _service.ObterTodos();
    }
}
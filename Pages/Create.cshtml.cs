using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGrassAppWeb.Pages;

public class Create : PageModel
{
    public SelectList MarcaOptionItems { get; set; }
    private IGrassService _service;
    

    public Create(IGrassService serivce)
    {
        _service = serivce;
    }

    public void OnGet()
    {
        MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
            nameof(Marca.MarcaId),
            nameof(Marca.Descricao));
    }
    
    
    [BindProperty] public Servico Servico { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();
        //inclusão
        _service.Incluir(Servico);
        return RedirectToPage("/Index");
    }
}
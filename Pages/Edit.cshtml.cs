using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGrassAppWeb.Pages;

public class Edit : PageModel
{
    
    public SelectList MarcaOptionItems { get; set; }
    private IGrassService _service;

    public Edit(IGrassService serivce)
    {
        _service = serivce;
    }

    [BindProperty] public Servico Servico { get; set; }


    public IActionResult OnGet(int id)
    {
        Servico = _service.Obter(id);

        MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
            nameof(Marca.MarcaId),
            nameof(Marca.Descricao));

        if (Servico == null) return NotFound();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();
        //alteração
        _service.Alterar(Servico);
        return RedirectToPage("/Index");
    }

    public IActionResult OnPostExclusao()
    {
        //exclusão
        _service.Excluir(Servico.ServicoId);

        return RedirectToPage("/Index");
    }
}
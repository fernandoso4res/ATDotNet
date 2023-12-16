using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGrassAppWeb.Pages;

[Authorize]
public class Edit : PageModel
{
    
    public SelectList MarcaOptionItems { get; set; }
    public SelectList CategoriaOptionItems { get; set; }
    private IGrassService _service;

    public Edit(IGrassService serivce)
    {
        _service = serivce;
    }

    [BindProperty] public Servico Servico { get; set; }
    [BindProperty] public IList<int> CategoriaIds { get; set; }


    public IActionResult OnGet(int id)
    {
        Servico = _service.Obter(id);
        CategoriaIds = Servico.Categorias.Select(item => item.CategoriaId).ToList();

        MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
            nameof(Marca.MarcaId),
            nameof(Marca.Descricao));
        
        CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
            nameof(Categoria.CategoriaId),
            nameof(Categoria.Descricao));

        if (Servico == null) return NotFound();

        return Page();
    }

    public IActionResult OnPost()
    {
        Servico.Categorias = _service.ObterTodasCategorias()
            .Where(item => CategoriaIds.Contains(item.CategoriaId))
            .ToList();
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
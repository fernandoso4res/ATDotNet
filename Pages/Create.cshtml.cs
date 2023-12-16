using CleanGrassAppWeb.Models;
using CleanGrassAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGrassAppWeb.Pages;

[Authorize]
public class Create : PageModel
{
    public SelectList MarcaOptionItems { get; set; }
    public SelectList CategoriaOptionItems { get; set; }
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
        
        CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
            nameof(Categoria.CategoriaId),
            nameof(Categoria.Descricao));
    }
    
    
    [BindProperty] 
    public Servico Servico { get; set; }
    
    [BindProperty] 
    public IList<int> CategoriaIds { get; set; }
    public IActionResult OnPost()
    {
        Servico.Categorias = _service.ObterTodasCategorias().Where(item => CategoriaIds.Contains(item.CategoriaId))
            .ToList();
        if (!ModelState.IsValid)
        {
            return Page();
        }
            
        //inclusão
        _service.Incluir(Servico);
        return RedirectToPage("/Index");
    }
}
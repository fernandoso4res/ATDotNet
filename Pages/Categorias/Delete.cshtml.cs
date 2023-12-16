using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CleanGrassAppWeb.Data;
using CleanGrassAppWeb.Models;

namespace CleanGrassAppWeb.Pages.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly CleanGrassAppWeb.Data.CleanGrassDbContext _context;

        public DeleteModel(CleanGrassAppWeb.Data.CleanGrassDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FirstOrDefaultAsync(m => m.CategoriaId == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FindAsync(id);

            if (Categoria != null)
            {
                _context.Categoria.Remove(Categoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

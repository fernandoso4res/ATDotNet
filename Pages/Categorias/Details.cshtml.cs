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
    public class DetailsModel : PageModel
    {
        private readonly CleanGrassAppWeb.Data.CleanGrassDbContext _context;

        public DetailsModel(CleanGrassAppWeb.Data.CleanGrassDbContext context)
        {
            _context = context;
        }

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
    }
}

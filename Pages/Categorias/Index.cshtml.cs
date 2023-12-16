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
    public class IndexModel : PageModel
    {
        private readonly CleanGrassAppWeb.Data.CleanGrassDbContext _context;

        public IndexModel(CleanGrassAppWeb.Data.CleanGrassDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categoria.ToListAsync();
        }
    }
}

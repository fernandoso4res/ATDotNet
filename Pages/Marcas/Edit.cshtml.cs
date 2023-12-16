using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanGrassAppWeb.Data;
using CleanGrassAppWeb.Models;

namespace CleanGrassAppWeb.Pages.Marcas
{
    public class EditModel : PageModel
    {
        private readonly CleanGrassAppWeb.Data.CleanGrassDbContext _context;

        public EditModel(CleanGrassAppWeb.Data.CleanGrassDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marca Marca { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marca = await _context.Marca.FirstOrDefaultAsync(m => m.MarcaId == id);

            if (Marca == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(Marca.MarcaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.MarcaId == id);
        }
    }
}

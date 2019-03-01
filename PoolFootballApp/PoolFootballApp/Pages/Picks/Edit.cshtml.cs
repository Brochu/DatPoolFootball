using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Picks
{
    public class EditModel : PageModel
    {
        private readonly PoolFootballApp.Models.NFLContext _context;

        public EditModel(PoolFootballApp.Models.NFLContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pick Pick { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pick = await _context.Picks
                .Include(p => p.Match).FirstOrDefaultAsync(m => m.Id == id);

            if (Pick == null)
            {
                return NotFound();
            }
           ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pick).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickExists(Pick.Id))
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

        private bool PickExists(int id)
        {
            return _context.Picks.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Matches
{
    public class DetailsModel : PageModel
    {
        private readonly PoolFootballApp.Models.NFLContext _context;

        public DetailsModel(PoolFootballApp.Models.NFLContext context)
        {
            _context = context;
        }

        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam).FirstOrDefaultAsync(m => m.Id == id);

            if (Match == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

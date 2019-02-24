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
	public class IndexModel : PageModel
	{
		private readonly PoolFootballApp.Models.NFLContext _context;

		public IndexModel(PoolFootballApp.Models.NFLContext context)
		{
			_context = context;
		}

		// TODO: Create custom routing to change route to *url*/Matches/*season*/*week*
		[BindProperty(SupportsGet = true)]
		public int Season { get; set; }
		[BindProperty(SupportsGet = true)]
		public int Week { get; set; }

		public IList<Match> Matches { get; set; }

		public async Task OnGetAsync()
		{
			if (Season == 0)
			{
				// So season given, list all season in DB to choose
				// return multiple selection list to user
			}
			else if (Week == 0)
			{
				// So week given, list all week for the given season in DB to choose
				// return multiple selection list to user
			}
			else
			{
				ViewData["Subtitle"] = string.Format("Matches from the Season {0}, Week {1}", Season, Week);

				Matches = await _context.Matches
					.Where(m => m.Season == Season)
					.Where(m => m.Week == Week)

					.Include(m => m.AwayTeam)
					.Include(m => m.HomeTeam)

					.ToListAsync();
			}
		}
	}
}

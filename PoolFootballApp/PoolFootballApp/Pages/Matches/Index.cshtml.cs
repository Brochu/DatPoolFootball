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

		[BindProperty(SupportsGet = true)]
		public int Season { get; set; }
		public Dictionary<int, List<Match>> Matches { get;set; }

		public async Task OnGetAsync()
		{
			if (Season == 0)
			{
				// So season given, list all season in DB to choose
				// return multiple selection list to user
			}
			else
			{
				ViewData["Season"] = string.Format("{0} Season :", Season);

				Matches = new Dictionary<int, List<Match>>();
				await _context.Matches
					.Where(m => m.Season == Season)

					.Include(m => m.AwayTeam)
					.Include(m => m.HomeTeam)

					.OrderBy(m => m.Season)
					.ThenBy(m => m.Week)

					.ForEachAsync((m) =>
					{
						if (!Matches.ContainsKey(m.Week))
						{
							Matches.Add(m.Week, new List<Match>());
						}
						Matches[m.Week].Add(m);
					});
			}
		}
	}
}

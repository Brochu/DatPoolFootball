using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Scores
{
	public class IndexModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public IndexModel(NFLContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public int Season { get; set; }

		public Dictionary<string, string> UsersLookup { get; set; }

		public async Task OnGetAsync()
		{
			string userId = _userManager.GetUserId(User);

			Pool pool = await _context.Pools
				.Where(p => p.UserId.Equals(userId))
				.FirstOrDefaultAsync();

			UsersLookup = new Dictionary<string, string>();
			if (pool != null)
			{
				// Fetch all players in the pool
			}
			else
			{
				UsersLookup.Add(userId, _userManager.GetUserName(User));
			}

			Dictionary<int, List<int>> matchIds = new Dictionary<int, List<int>>();
			await _context.Matches
				.Where(m => m.Season == Season)
				.ForEachAsync(m =>
				{
					if (!matchIds.ContainsKey(m.Week))
					{
						matchIds.Add(m.Week, new List<int>());
					}
					matchIds[m.Week].Add(m.Id);
				});
			
			// We want to tally scores for each week in season given, default current
			// Render a table with results week per week, and total at the bottom
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Scores
{
	public class IndexModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly IConfiguration _config;
		private readonly UserManager<IdentityUser> _userManager;

		public IndexModel(NFLContext context, IConfiguration config, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_config = config;
			_userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public int Season { get; set; }

		public Dictionary<string, string> UsersLookup { get; set; }
		public Dictionary<int, Dictionary<string, int>> UserScores { get; set; }
		public Dictionary<int, int> PossibleScores { get; set; }

		public async Task OnGetAsync()
		{
			if (Season == 0)
			{
				Season = _config.GetValue<int>("Values:CurrentSeason");
			}
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

			UserScores = new Dictionary<int, Dictionary<string, int>>();
			await _context.Picks
				.Where(p => UsersLookup.ContainsKey(p.UserId))
				.Include(p => p.Match)
				.Where(p => p.Match.Season == Season)
				.ForEachAsync(p =>
				{
					if (!UserScores.ContainsKey(p.Match.Week))
					{
						UserScores.Add(p.Match.Week, new Dictionary<string, int>());
					}
					if (!UserScores[p.Match.Week].ContainsKey(p.UserId))
					{
						UserScores[p.Match.Week].Add(p.UserId, 0);
					}

					if (p.Choice == MatchPick.Away && p.Match.AwayScore > p.Match.HomeScore ||
						p.Choice == MatchPick.Home && p.Match.HomeScore > p.Match.AwayScore)
					{
						UserScores[p.Match.Week][p.UserId] += 1;
					}
				});

			// There might be a better way to get the possible scores
			PossibleScores = new Dictionary<int, int>();
			await _context.Matches
				.Where(m => m.Season == Season)
				.ForEachAsync(m =>
				{
					if (!PossibleScores.ContainsKey(m.Week))
					{
						PossibleScores.Add(m.Week, 0);
					}
					PossibleScores[m.Week] += 1;
				});
		}
	}
}

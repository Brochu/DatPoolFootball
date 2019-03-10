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
		public class UserScore
		{
			public string UserId;
			public int Score;

			public void CountWin()
			{
				Score++;
			}
		}

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
		public Dictionary<int, List<UserScore>> UserScores { get; set; }
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

			UserScores = new Dictionary<int, List<UserScore>>();
			await _context.Picks
				.Where(p => UsersLookup.ContainsKey(p.UserId))
				.Include(p => p.Match)
				.Where(p => p.Match.Season == Season)
				.GroupBy(p => p.Match.Week)
				.ForEachAsync(g =>
				{
					UserScores.Add(g.Key, new List<UserScore>());
					foreach (var id in UsersLookup.Keys)
					{
						UserScores[g.Key].Add(new UserScore { UserId = id, Score = 0 });
					}

					foreach (var pick in g.ToArray())
					{
						if (pick.Choice == MatchPick.Away && pick.Match.AwayScore > pick.Match.HomeScore ||
							pick.Choice == MatchPick.Home && pick.Match.HomeScore > pick.Match.AwayScore)
						{
							UserScores[g.Key].Find(s => s.UserId.Equals(pick.UserId)).CountWin();
						}
					}
				});


			// There might be a better way to get the possible scores
			PossibleScores = new Dictionary<int, int>();
			await _context.Matches
				.Where(m => m.Season == Season)
				.GroupBy(m => m.Week)
				.ForEachAsync(g =>
				{
					PossibleScores.Add(g.Key, g.Count());
				});
		}
	}
}

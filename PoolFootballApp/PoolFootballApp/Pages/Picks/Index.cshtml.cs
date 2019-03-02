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

namespace PoolFootballApp.Pages.Picks
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
		[BindProperty(SupportsGet = true)]
		public int Week { get; set; }

		public Dictionary<string, string> UsersLookup { get; set; }
		public IList<Match> Matches { get; set; }
		public Dictionary<int, IList<Pick>> PicksLookup { get; set; }

		public async Task OnGetAsync()
		{
			// Get parameters data
			if (Season == 0)
			{
				Season = int.Parse(_config["Values:CurrentSeason"]);
			}
			if (Week == 0)
			{
				//TimeSpan span = (DateTime.Today - DateTime.Parse(_config["Values:StartDate"]));
				//Week = ((int)(span.TotalDays / 7)) + 1;

				// TEMP OVERRIDE
				Week = 1;
			}

			// Get user related data
			Pool current = _context.Pools
				.Where(p => p.UserId == _userManager.GetUserId(User))
				.FirstOrDefault();
			UsersLookup = new Dictionary<string, string>();

			if (current == null)
			{
				UsersLookup.Add(_userManager.GetUserId(User), _userManager.GetUserName(User));
			}
			else
			{
				await _context.Pools
					.Where(p => p.PoolName.Equals(current.PoolName))
					.ForEachAsync(p => { UsersLookup[p.UserId] = p.UserName; });
			}

			// Get matches for given week/season
			Matches = await _context.Matches
				.Where(m => m.Season == Season && m.Week == Week)

				.Include(m => m.AwayTeam)
				.Include(m => m.HomeTeam)

				.ToListAsync();
			HashSet<int> matchIds = new HashSet<int>(Matches.Select(m => m.Id));

			// Get all related picks for matches
			PicksLookup = new Dictionary<int, IList<Pick>>();
			await _context.Picks
				.Where(p => matchIds.Contains(p.MatchId))
				.ForEachAsync(p =>
				{
					if (!PicksLookup.ContainsKey(p.MatchId))
					{
						PicksLookup.Add(p.MatchId, new List<Pick>());
					}
					PicksLookup[p.MatchId].Add(p);
				});
		}
	}
}

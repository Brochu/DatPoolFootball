using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Picks
{
	public class EditModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly IConfiguration _config;
		private readonly UserManager<IdentityUser> _userManager;

		public EditModel(NFLContext context, IConfiguration config, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_config = config;
			_userManager = userManager;
		}

		public bool AnyMatchStarted { get; private set; }
		public List<int> MatchIds;
		[BindProperty]
		public List<Pick> Picks { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			CheckMatchStarted();

			int season = _config.GetValue<int>("Values:CurrentSeason");
			//TimeSpan span = (DateTime.Today - DateTime.Parse(_config["Values:StartDate"]));
			//int week = ((int)(span.TotalDays / 7)) + 1;
			// TEMP VALUE FOR TESTING
			int week = 1;
			string userId = _userManager.GetUserId(User);

			bool addedAny = false;
			MatchIds = new List<int>();
			await _context.Matches
				.Where(m => m.Season == season && m.Week == week)
				.OrderBy(m => m.WeekDay)
				.ThenBy(m => m.StartTime)
				.Select(m => m.Id)
				.ForEachAsync(id =>
				{
					MatchIds.Add(id);
					if (!_context.Picks.Any(p => p.MatchId == id && p.UserId.Equals(userId)))
					{
						_context.Picks.Add(new Pick() { MatchId = id, UserId = userId });
						addedAny = true;
					}
				});

			if (addedAny)
			{
				_context.SaveChanges();
			}

			Picks = await _context.Picks
				.Where(p => MatchIds.Contains(p.MatchId) && p.UserId.Equals(userId))

				.Include(p => p.Match)
				.ThenInclude(m => m.AwayTeam)
				.Include(p => p.Match)
				.ThenInclude(m => m.HomeTeam)

				.ToListAsync();

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			foreach (Pick pick in Picks)
			{
				_context.Attach(pick).State = EntityState.Modified;
			}

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException e)
			{
				Console.WriteLine("ERROR : " + e.Message);
			}

			return RedirectToPage("./Index");
		}

		private void CheckMatchStarted()
		{
			// Need to add logic to check if any match started
			AnyMatchStarted = false;
		}
	}
}

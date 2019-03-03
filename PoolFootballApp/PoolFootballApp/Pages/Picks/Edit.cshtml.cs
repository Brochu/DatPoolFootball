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

		[BindProperty]
		public Pick Pick { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			int season = _config.GetValue<int>("Values:CurrentSeason");
			// TEMP VALUE FOR TESTING
			int week = 1;
			string userId = _userManager.GetUserId(User);

			bool addedAny = false;
			List<int> matchIds = new List<int>();
			await _context.Matches
				.Where(m => m.Season == season && m.Week == week)
				.OrderBy(m => m.WeekDay)
				.ThenBy(m => m.StartTime)
				.Select(m => m.Id)
				.ForEachAsync(id =>
				{
					matchIds.Add(id);
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

			// SELECT ALL THE PICKS FOR THE GIVEN WEEK
			//Pick = await _context.Picks
			//	.Include(p => p.Match).FirstOrDefaultAsync(m => m.Id == id);

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

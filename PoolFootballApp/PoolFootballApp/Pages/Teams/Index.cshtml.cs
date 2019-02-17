using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Teams
{
	public class IndexModel : PageModel
	{
		private readonly PoolFootballApp.Models.NFLContext _context;

		public IndexModel(PoolFootballApp.Models.NFLContext context)
		{
			_context = context;
		}

		public IList<Team> Team { get;set; }

		public async Task OnGetAsync()
		{
			Team = await _context.Team
				.OrderBy(t => (int)t.Conf)
				.ThenBy(t => (int)t.Div)
				.ToListAsync();
		}
	}
}

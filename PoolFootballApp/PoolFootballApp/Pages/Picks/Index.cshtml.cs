using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public IndexModel(NFLContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}

		[BindProperty(SupportsGet = true)]
		public int Season { get; set; }
		[BindProperty(SupportsGet = true)]
		public int Week { get; set; }

		public IList<Pick> Pick { get;set; }

		public async Task OnGetAsync()
		{
			if (Season == 0)
			{
				Season = int.Parse(_config["Values:CurrentSeason"]);
			}
			if (Week == 0)
			{
				TimeSpan span = (DateTime.Today - DateTime.Parse(_config["Values:StartDate"]));
				Week = ((int)(span.TotalDays / 7)) + 1;
			}

			Pick = await _context.Picks
				.Include(p => p.Match).ToListAsync();
		}
	}
}

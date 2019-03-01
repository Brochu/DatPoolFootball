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

		public IList<Pick> Pick { get;set; }

		public async Task OnGetAsync()
		{
			Pick = await _context.Picks
				.Include(p => p.Match).ToListAsync();
		}
	}
}

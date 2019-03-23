using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Messages
{
	public class IndexModel : PageModel
	{
		private readonly NFLContext _context;

		public IndexModel(NFLContext context)
		{
			_context = context;
		}

		public IList<Message> Message { get;set; }

		public async Task OnGetAsync()
		{
			Message = await _context.Messages
				.OrderBy(m => m.PostTime)
				.ToListAsync();
		}
	}
}

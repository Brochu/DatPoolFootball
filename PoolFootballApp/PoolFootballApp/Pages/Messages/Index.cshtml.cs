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
		private readonly int _pageCount = 10;

		public IndexModel(NFLContext context)
		{
			_context = context;
		}

		[BindProperty(SupportsGet = true)]
		public int pageIndex { get; set; }

		public IList<Message> Message { get;set; }

		public async Task OnGetAsync()
		{
			Message = await _context.Messages
				.OrderByDescending(m => m.PostTime)
				.Skip(_pageCount * pageIndex)
				.Take(_pageCount)
				.ToListAsync();
		}
	}
}

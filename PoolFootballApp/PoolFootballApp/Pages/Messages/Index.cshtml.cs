using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Messages
{
	public class IndexModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly int _pageCount = 10;

		public IndexModel(NFLContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public int pageIndex { get; set; }

		public IList<Message> Messages { get;set; }

		public async Task OnGetAsync()
		{
			List<string> userIds;
			Pool current = _context.Pools
				.Where(p => p.UserId == _userManager.GetUserId(User))
				.FirstOrDefault();

			if (current != null)
			{
				userIds = await _context.Pools
					.Where(p => p.PoolName.Equals(current.PoolName))
					.Select(p => p.UserId)
					.ToListAsync();

				Messages = await _context.Messages
					.Where(m => userIds.Contains(m.UserId))
					.OrderByDescending(m => m.PostTime)
					.Skip(_pageCount * pageIndex)
					.Take(_pageCount)
					.ToListAsync();
			}
		}
	}
}

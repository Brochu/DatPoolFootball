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
	public class DetailsModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public DetailsModel(NFLContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public string CurrentUser { get; set; }
		public Message Message { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			CurrentUser = _userManager.GetUserId(User);

			if (id == null)
			{
				return NotFound();
			}

			Message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);

			if (Message == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}

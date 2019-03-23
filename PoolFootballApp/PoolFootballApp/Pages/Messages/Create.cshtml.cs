using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoolFootballApp.Models;

namespace PoolFootballApp.Pages.Messages
{
	public class CreateModel : PageModel
	{
		private readonly NFLContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public CreateModel(NFLContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Message Message { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Message.PostTime = DateTime.Now;
			Message.UserId = _userManager.GetUserId(User);
			_context.Messages.Add(Message);

			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
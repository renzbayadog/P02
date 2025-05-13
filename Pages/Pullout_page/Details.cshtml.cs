using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using IdigitalCafe.ViewModels; 
using IdigitalCafe.Data.Entities; 
using IdigitalCafe.Data; 
using codegen.Helpers; 


namespace IdigitalCafe.Pages.Pullout_page.Pullout_pge
{
	//[Authorize]
	public class DetailsModel : PageModel
	{
		private readonly AppDB1Context _context;

		public DetailsModel(AppDB1Context context)
		{
			_context = context;
		}

		[BindProperty]
		public PulloutVM Pullout { get; set; }

		public async Task<IActionResult> OnGet(int? id)
        {
			
			if (id == null)
			{
				return RedirectToPage("Index");
			}

			var pullout = await _context.Pullouts
							.Include(sales => sales.Sales)
							.AsNoTracking()
							.FirstOrDefaultAsync(m => m.PulloutId == id);

			if (pullout == null)
			{
				return RedirectToPage("Index");
			}
			
			Pullout = new PulloutVM()
			{
				PulloutId = pullout.PulloutId,
				PulloutName = pullout.PulloutName,
				PulloutDescription = pullout.PulloutDescription,
				PulloutDate = pullout.PulloutDate,
				SalesId = pullout.Sales?.SalesId,
				ReceiptImage = pullout.ReceiptImage,
				businessValue = pullout.businessValue,
				SalesName = pullout.Sales?.SalesName
			};

            return Page();
		}
	}
}
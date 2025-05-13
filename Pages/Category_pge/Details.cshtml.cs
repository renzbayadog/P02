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
using IdigitalCafe.Data.Repositories; 
using codegen.Helpers; 
using codegen.Data.Repositories; 


namespace IdigitalCafe.Pages.Category_pge.Category_pge
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
		public CategoryVM Category { get; set; }

		public async Task<IActionResult> OnGet(int? id)
        {
			
			if (id == null)
			{
				return RedirectToPage("Index");
			}

			var category = await _context.Categories
							
							.AsNoTracking()
							.FirstOrDefaultAsync(m => m.CategoryId == id);

			if (category == null)
			{
				return RedirectToPage("Index");
			}
			
			Category = new CategoryVM()
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName
			};

            return Page();
		}
	}
}
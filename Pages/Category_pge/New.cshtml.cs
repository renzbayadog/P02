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
    public class NewModel : PageModel
    {
        private readonly AppDB1Context _context;

        public NewModel(AppDB1Context context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public CategoryVM Category { get; set; }

		public IActionResult OnGet()
        {
			
			return Page();
        }

   //     public async Task<IActionResult> OnPostAsync()
   //     {
   //         if (!ModelState.IsValid)
   //         {
   //             return Page();
   //         }

			//Product productToAdd = new Product()
			//{
			//	GradeLevelId = Product.GradeLevelId,
			//	LocationId = Product.LocationId,
			//	ProductName = Product.ProductName,
			//	//CategoryId = Product.CategoryId
			//};

   //         _context.Products.Add(productToAdd);
   //         await _context.SaveChangesAsync();

   //         Message = "Successfully inserted data!";

   //         return RedirectToPage("Index");
   //     }

    }
}
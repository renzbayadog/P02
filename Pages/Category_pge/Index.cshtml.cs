using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class IndexModel : PageModel
    {
        private readonly AppDB1Context _context;
		
		public IList<CategoryVM> Categories { get; set; }

        public IndexModel(AppDB1Context context)
        {
            _context = context;
        }
    }
}
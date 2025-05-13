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
using codegen.Helpers; 


namespace IdigitalCafe.Pages.Pullout_page.Pullout_pge
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppDB1Context _context;
		
		public IList<PulloutVM> Pullouts { get; set; }

        public IndexModel(AppDB1Context context)
        {
            _context = context;
        }
    }
}
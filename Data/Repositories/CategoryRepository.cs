using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdigitalCafe.ViewModels; 
using IdigitalCafe.Data.Entities; 
using IdigitalCafe.Data; 
using codegen.Helpers; 
using codegen.Data.Repositories; 


namespace IdigitalCafe.Data.Repositories
{
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly AppDB1Context _context;

        public CategoryRepository(AppDB1Context context) : base(context)
        {
            _context = context;
        }
  
        public async Task<List<Category>> GetAllCategoryQry(CategorySearch searchInfo)
        {
            List<Category> categories = await _context.Categories
						
						.AsNoTracking().ToListAsync();
			

				//.Where(f => searchInfo.DateFrom == null || f.CreateDate >= searchInfo.DateFrom)
				//.Where(f => searchInfo.DateTo == null || f.CreateDate <= searchInfo.DateTo)
				//.OrderByDescending(s => s.CreateDate).ToList();

				//if (!String.IsNullOrEmpty(searchInfo.SortOrder))
				//{
				//	var sortCurrent = searchInfo.SortOrder.Split("_").Last();
				//	var sortCurrent = searchInfo.SortOrder.Split("_").First();
				//	if (sortCurrent.Equals("DESC"))
				//	{
				//		products.OrderByDescending(a=>a.)
				//	}
				//}
            
            return categories;
        }

    }
}
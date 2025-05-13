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
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<List<Category>> GetAllCategoryQry(CategorySearch searchInfo);
    }
}
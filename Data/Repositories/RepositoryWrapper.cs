using IdigitalCafe.Data.Entities;
using IdigitalCafe.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace codegen.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICategoryRepository _categoryRepository;
        private AppDB1Context _context;

        public RepositoryWrapper(AppDB1Context context)
        {
            _context = context;
        }

        public ICategoryRepository categoryRepository
        {
            get
            {
                if (_categoryRepository == null) _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        //register service here

    }
    public interface IRepositoryWrapper
    {
        ICategoryRepository categoryRepository { get; }

        //register service here
    }
}

using TestCoreApp.Data;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        { 
           _context = context;
           categories = new MainRepository<Category>(_context);
           items = new MainRepository<Food>(_context);
        }

        private readonly AppDbContext _context;

        public IRepository<Category> categories { get; private set; }

        public IRepository<Food> items { get; private set; }


        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

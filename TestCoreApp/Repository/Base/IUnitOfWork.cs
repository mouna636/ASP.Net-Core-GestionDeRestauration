using TestCoreApp.Models;

namespace TestCoreApp.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get;  }
        IRepository<Food> items { get; }
       
        int CommitChanges();
    }
}

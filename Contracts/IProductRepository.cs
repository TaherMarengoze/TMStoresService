using EntitiesCore.Models;

namespace Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Product GetById(long id);
    }
}
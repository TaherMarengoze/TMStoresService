using Contracts;
using EntitiesCore;
using EntitiesCore.Models;
using System.Linq;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(TMStoresContext storesContext)
            : base(storesContext)
        {
        }

        public Product GetById(long id)
        {
            return FindByCondition(p => p.Id == id).FirstOrDefault();
        }

        //public void DeleteById(long id)
        //{
        //    var product = FindByCondition(p => p.Id == id).FirstOrDefault();
        //    if (product != null)
        //    {
        //        Delete(product);
        //    }
        //}
    }
}
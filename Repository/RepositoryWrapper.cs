using Contracts;
using EntitiesCore;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TMStoresContext storesContext;

        private IProductRepository product;

        public RepositoryWrapper(TMStoresContext reposContext)
        {
            storesContext = reposContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(storesContext);

                return product;
            }
        }

        public void Save()
        {
            storesContext.SaveChanges();
        }
    }
}
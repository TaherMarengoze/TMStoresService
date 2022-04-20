namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }

        void Save();
    }
}
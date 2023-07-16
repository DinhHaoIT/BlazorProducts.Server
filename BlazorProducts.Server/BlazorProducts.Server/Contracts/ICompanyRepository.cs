using BlazorProducts.Server.Entities;

namespace BlazorProducts.Server.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}

using BlazorProducts.Server.Entities;
using BlazorProducts.Server.Entities.RequestFeatures;
using BlazorProducts.Server.Paging;

namespace BlazorProducts.Server.Contracts
{
    public interface ICompanyRepository
    {
        Task<PagedList<Company>> GetCompanies(CompanyParameters companyParameters);

    }
}

using BlazorProducts.Server.Context;
using BlazorProducts.Server.Contracts;
using BlazorProducts.Server.Entities;
using BlazorProducts.Server.Entities.RequestFeatures;
using BlazorProducts.Server.Paging;
using Dapper;

namespace BlazorProducts.Server.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

       

        public async Task<PagedList<Company>> GetCompanies(CompanyParameters companyParameters)
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return PagedList<Company>
                       .ToPagedList(companies, companyParameters.PageNumber, companyParameters.PageSize);
            }
        }
    }
}

using BlazorProducts.Server.Contracts;
using BlazorProducts.Server.Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        public CompaniesController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CompanyParameters companyParameters)
        {
            try
            {
                var companies = await _companyRepo.GetCompanies(companyParameters);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(companies.MetaData));
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}

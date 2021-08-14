using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutosServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveAllProductsController : ControllerBase
    {
        private readonly ProductoBusiness _productBusiness;
        public RetrieveAllProductsController(ProductoBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET: api/<RetrieveAllProducts>/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<ProductoResponse> GetAll()
        {
            ProductoResponse result = new ProductoResponse();
            try
            {
                result = await _productBusiness.RetrieveAll();
            }
            catch (Exception ex)
            {
                result.Description = ex.Message;
                result.ErrorList.Add(ex);
            }
            return result; 
        }

    }
}

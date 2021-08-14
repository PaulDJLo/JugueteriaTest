using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveByIdController : ControllerBase
    {
        private readonly ProductoBusiness _productBusiness;

        public RetrieveByIdController(ProductoBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ProductoResponse> GetById(int id)
        {
            ProductoResponse result = new ProductoResponse();
            Producto find = new Producto(id);
            try
            {
                result = await _productBusiness.RetrieveById(find);
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

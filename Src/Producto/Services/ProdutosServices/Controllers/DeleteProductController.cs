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
    public class DeleteProductController : ControllerBase
    {
        private readonly ProductoBusiness _productBusiness;

        public DeleteProductController(ProductoBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // DELETE api/<DeleteProductController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ProductoResponse> Delete(int id)
        {
            Producto createdP = new Producto(id);
            ProductoResponse result = new ProductoResponse();
            try
            {
                result = await _productBusiness.Delete(createdP);
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

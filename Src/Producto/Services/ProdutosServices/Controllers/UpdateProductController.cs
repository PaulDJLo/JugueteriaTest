using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController : Controller
    {
        private readonly ProductoBusiness _productBusiness;

        public UpdateProductController(ProductoBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ProductoResponse> Update([FromBody] Producto newProduct)
        {
            ProductoResponse result = new ProductoResponse();
            try
            {
                result = await _productBusiness.Update(newProduct);
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

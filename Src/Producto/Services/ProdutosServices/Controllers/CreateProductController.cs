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
    public class CreateProductController : Controller
    {
        private readonly ProductoBusiness _productBusiness;

        public CreateProductController(ProductoBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }
        // GET: CrearProductoController
        [HttpPost]
        [Route("Create")]
        public async Task<ProductoResponse> Create([FromBody] Producto newProduct)
        {
            ProductoResponse result = new ProductoResponse();
            try
            {
                 result = await _productBusiness.Create(newProduct);
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

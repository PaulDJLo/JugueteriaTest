
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutosServices.Controllers
{
    [Route("api/[controller]")]
    public class RetrieveAllProductsController : ControllerBase
    {
        private readonly String apiBaseUrl;

        public RetrieveAllProductsController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("RetrieveProductsUrl");
        }
        // GET: api/<RetrieveAllProducts>/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Producto> GetAll()
        {
            ProductoResponse result = new ProductoResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var responseTask = client.GetAsync(apiBaseUrl).Result;
                    if (responseTask.IsSuccessStatusCode)
                    {
                        result = HttpContentExtensions.ReadAsAsync<ProductoResponse>(responseTask.Content).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Description = ex.Message;
                result.ErrorList.Add(ex);
            }
            return result.Productos;
        }

    }
}

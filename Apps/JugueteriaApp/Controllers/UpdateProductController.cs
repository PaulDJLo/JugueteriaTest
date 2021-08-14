using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JugueteriaApp.Controllers
{
    [Route("api/[controller]")]
    public class UpdateProductController : Controller
    {
        private readonly String apiBaseUrl;

        public UpdateProductController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("UpdateProductUrl");
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            producto.Id = id;
            ProductoResponse result = new ProductoResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");

                    using (var response = await client.PutAsync(apiBaseUrl, content))
                    {
                        result = await HttpContentExtensions.ReadAsAsync<ProductoResponse>(response.Content);
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}

using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JugueteriaApp.Controllers
{
    [Route("api/[controller]")]
    public class RetrieveByIdController : Controller
    {
        private readonly String apiBaseUrl;


        public RetrieveByIdController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("RetrieveProductByIdUrl");
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Producto GetById(int id)
        {
            ProductoResponse result = new ProductoResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var responseTask =  client.GetAsync(apiBaseUrl + id).Result;
                    if (responseTask.IsSuccessStatusCode)
                    {
                        result =  HttpContentExtensions.ReadAsAsync<ProductoResponse>(responseTask.Content).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Description = ex.Message;
                result.ErrorList.Add(ex);
            }
            return result.Producto;
        }
    }
}

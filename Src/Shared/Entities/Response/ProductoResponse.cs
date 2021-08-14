using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductoResponse : ResponseBase
    {
        public List<Producto> Productos { get; set; }
        public Producto Producto { get; set; }

        public ProductoResponse()
        {
            Productos = new List<Producto>();
            ErrorList = new List<Exception>();
            IsSuccess = false;
        }

        public ProductoResponse(List<Producto> products)
        {
            Productos = products;
            ErrorList = new List<Exception>();
            IsSuccess = false;
        }

        public ProductoResponse(Producto product)
        {
            Producto = product;
            Productos = new List<Producto>();
            ErrorList = new List<Exception>();
            IsSuccess = false;
        }
    }
}

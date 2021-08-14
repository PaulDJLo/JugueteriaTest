using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductoBusiness
    {
        private readonly ProductoRepository _repository;
        public ProductoBusiness(ProductoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductoResponse> Create(Producto nuevoUsuario)
        {
            ProductoResponse productExist = await _repository.IsUserExist(nuevoUsuario);
            if (!productExist.IsSuccess)//si no existe el producto
            {
                productExist = await _repository.Create(nuevoUsuario);
            }
            return productExist;
        }

        public async Task<ProductoResponse> Delete(Producto borraUsuario)
        {
            return await _repository.Delete(borraUsuario);
        }
        public async Task<ProductoResponse> RetrieveAll()
        {
            return await _repository.RetrieveAll();
        }

        public async Task<ProductoResponse> RetrieveById(Producto existeUsuario)
        {
            return await _repository.RetrieveById(existeUsuario);
        }

        public async Task<ProductoResponse> Update(Producto actualizaUsuario)
        {
            return await _repository.Update(actualizaUsuario);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IRepository
    {
        Task<ProductoResponse> Create(Producto nuevoUsuario);

        Task<ProductoResponse> Update(Producto actualizaUsuario);

        Task<ProductoResponse> Delete(Producto borraUsuario);
        Task<ProductoResponse> IsUserExist(Producto existeUsuario);

        Task<ProductoResponse> RetrieveAll();
        Task<ProductoResponse> RetrieveById(Producto existeUsuario);
    }
}

using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductoRepository : IRepository
    {
        protected DbContext _context;
        protected DbSet<Producto> _productSet;
        public ProductoRepository(DbContext context)
        {
            _context = context;
            _productSet = context.Set<Producto>();
        }
        public IEnumerable<Producto> Where(Expression<Func<Producto, bool>> predicate)
        {
            return _productSet.Where(predicate);
        }
        public async Task<ProductoResponse> Create(Producto nuevoUsuario)
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                _productSet.Add(nuevoUsuario);
                _context.SaveChanges();
                response.Producto = nuevoUsuario;
                response.IsSuccess = true;
                response.Description = "Producto agregado correctamente";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }

            return response;
        }

        public async Task<ProductoResponse> Delete(Producto borraUsuario)
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                _productSet.Remove(borraUsuario);
                _context.SaveChanges();
                response.Producto = borraUsuario;
                response.IsSuccess = true;
                response.Description = "Producto borrado correctamente";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<ProductoResponse> IsUserExist(Producto existeUsuario)
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                Producto res = _productSet.Where(p => p.Nombre == existeUsuario.Nombre &&
                  p.Descripcion == existeUsuario.Descripcion &&
                  p.RestriccionEdad == existeUsuario.RestriccionEdad &&
                  p.Compania == existeUsuario.Compania &&
                  p.Precio == existeUsuario.Precio).FirstOrDefault();
                if (res is null)
                {
                    response.IsSuccess = false;
                    response.Description = "No existe dicho producto";
                }
                else
                {
                    response.IsSuccess = true;
                    response.Description = "Ya existe dicho producto¡";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }
            return response;

        }

        public async Task<ProductoResponse> RetrieveAll()
        {
            ProductoResponse response = new ProductoResponse();

            try
            {
                var list = await _productSet.ToListAsync();
                response = new ProductoResponse(list);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }

            return response;
        }

        public async Task<ProductoResponse> RetrieveById(Producto existeUsuario)
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                var result = await _productSet.FindAsync(existeUsuario.Id);
                if (result is null)
                {
                    response.IsSuccess = false;
                    response.Description = "Producto no encontrado";
                }
                else
                {
                    response.Producto = result;
                    response.IsSuccess = true;
                    response.Description = "Producto Encontrado";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }
            return response;

        }

        public async Task<ProductoResponse> Update(Producto actualizaUsuario)
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                _productSet.Update(actualizaUsuario);
                _context.SaveChanges();
                response.Producto = actualizaUsuario;
                response.IsSuccess = true;
                response.Description = "Producto actualizado correctamente¡";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(ex);
                response.Description = ex.Message;
            }
            return response;

        }
    }
}

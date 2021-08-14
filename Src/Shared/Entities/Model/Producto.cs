using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Producto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }
        [StringLength(100)]
        public String Descripcion { get; set; }
        [Range(0, 100)]
        public int RestriccionEdad { get; set; }

        [Required]
        [StringLength(50)]
        public String Compania { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Precio { get; set; }

        public String Imagenes { get; set; }

        public Producto(int id, String nombre, String descripcion, int restriccionEdad, String compania, double precio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            RestriccionEdad = restriccionEdad;
            Compania = compania;
            Precio = precio;
        }
        public Producto()
        {

        }
        public Producto(int id)
        {
            Id = id;
        }
    }
}

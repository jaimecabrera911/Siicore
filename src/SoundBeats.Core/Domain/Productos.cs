using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class Productos
    {
        public Productos()
        {
            DetalleRegistroCompras = new HashSet<DetalleRegistroCompras>();
            DetalleRegistroInventarios = new HashSet<DetalleRegistroInventarios>();
            DetalleRegistroVentas = new HashSet<DetalleRegistroVentas>();
        }

        public int IdProducto { get; set; }
        public int IdCategoriaProducto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string MarcaProducto { get; set; }
        public string MarcaCoche { get; set; }
        public string Referencia { get; set; }
        public string Modelo { get; set; }
        public string Lado { get; set; }
        public string Ubicacion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }

        public virtual CategoriaProductos IdCategoriaProductoNavigation { get; set; }
        public virtual ICollection<DetalleRegistroCompras> DetalleRegistroCompras { get; set; }
        public virtual ICollection<DetalleRegistroInventarios> DetalleRegistroInventarios { get; set; }
        public virtual ICollection<DetalleRegistroVentas> DetalleRegistroVentas { get; set; }
    }
}

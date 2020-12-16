using System;
using System.Collections.Generic;

namespace SoundBeats.Core.Domain
{
    public partial class CategoriaProductos
    {
        public CategoriaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdCategoriaProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}

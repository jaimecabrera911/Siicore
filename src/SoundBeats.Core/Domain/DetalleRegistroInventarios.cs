using System;
using System.Collections.Generic;

namespace SoundBeats.Core.Domain
{
    public partial class DetalleRegistroInventarios
    {
        public int IdDetalleRegistroInventario { get; set; }
        public int IdRegistroInventario { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual RegistroInventario IdRegistroInventarioNavigation { get; set; }
    }
}

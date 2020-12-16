using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class DetalleRegistroCompras
    {
        public int IdDetalleRegistroCompra { get; set; }
        public int IdRegistroCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal? Descuento { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual RegistroCompras IdRegistroCompraNavigation { get; set; }
    }
}

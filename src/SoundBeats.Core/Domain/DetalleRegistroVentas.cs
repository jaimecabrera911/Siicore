using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class DetalleRegistroVentas
    {
        public int IdDetalleRegistroVentas { get; set; }
        public int IdRegistroVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal? Descuento { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual RegistroVentas IdRegistroVentaNavigation { get; set; }
    }
}

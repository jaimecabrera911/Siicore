using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class RegistroCompras
    {
        public RegistroCompras()
        {
            DetalleRegistroCompras = new HashSet<DetalleRegistroCompras>();
        }

        public int IdRegistroCompra { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTercero { get; set; }
        public string TipoComprobante { get; set; }
        public string NumComprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
        public virtual Terceros IdTerceroNavigation { get; set; }
        public virtual ICollection<DetalleRegistroCompras> DetalleRegistroCompras { get; set; }
    }
}

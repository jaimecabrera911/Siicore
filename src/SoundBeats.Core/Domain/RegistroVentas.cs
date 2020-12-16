using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class RegistroVentas
    {
        public RegistroVentas()
        {
            DetalleRegistroVentas = new HashSet<DetalleRegistroVentas>();
        }

        public int IdRegistroVenta { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTercero { get; set; }
        public string TipoComprobante { get; set; }
        public string NumComprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
        public virtual Terceros IdTerceroNavigation { get; set; }
        public virtual ICollection<DetalleRegistroVentas> DetalleRegistroVentas { get; set; }
    }
}

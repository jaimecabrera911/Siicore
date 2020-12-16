using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class RegistroInventario
    {
        public RegistroInventario()
        {
            DetalleRegistroInventarios = new HashSet<DetalleRegistroInventarios>();
        }

        public int IdRegistroInventario { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTercero { get; set; }
        public string TipoComprobante { get; set; }
        public string NumComprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
        public virtual Terceros IdTerceroNavigation { get; set; }
        public virtual ICollection<DetalleRegistroInventarios> DetalleRegistroInventarios { get; set; }
    }
}

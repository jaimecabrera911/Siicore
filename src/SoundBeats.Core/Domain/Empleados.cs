using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class Empleados
    {
        public Empleados()
        {
            RegistroCompras = new HashSet<RegistroCompras>();
            RegistroInventario = new HashSet<RegistroInventario>();
            RegistroVentas = new HashSet<RegistroVentas>();
        }

        public int IdEmpleado { get; set; }
        public int IdUsuario { get; set; }
        public int? IdCargo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

        public virtual Cargos IdCargoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<RegistroCompras> RegistroCompras { get; set; }
        public virtual ICollection<RegistroInventario> RegistroInventario { get; set; }
        public virtual ICollection<RegistroVentas> RegistroVentas { get; set; }
    }
}

using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class Terceros
    {
        public Terceros()
        {
            RegistroCompras = new HashSet<RegistroCompras>();
            RegistroInventario = new HashSet<RegistroInventario>();
            RegistroVentas = new HashSet<RegistroVentas>();
        }

        public int IdTercero { get; set; }
        public int? IdCategoriaTercero { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public string PersonaContacto { get; set; }
        public string TelefonContacto { get; set; }
        public bool? Estado { get; set; }

        public virtual CategoriaTercero IdCategoriaTerceroNavigation { get; set; }
        public virtual ICollection<RegistroCompras> RegistroCompras { get; set; }
        public virtual ICollection<RegistroInventario> RegistroInventario { get; set; }
        public virtual ICollection<RegistroVentas> RegistroVentas { get; set; }
    }
}

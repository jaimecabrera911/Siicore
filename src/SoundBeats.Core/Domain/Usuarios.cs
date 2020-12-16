using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}

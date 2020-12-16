using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SoundBeats.Core.Domain
{
    public partial class RegRoles
    {
        public int IdRegRol { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }
    }
}

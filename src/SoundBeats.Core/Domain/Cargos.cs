using System;
using System.Collections.Generic;

namespace SoundBeats.Core.Domain
{
    public partial class Cargos
    {
        public Cargos()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}

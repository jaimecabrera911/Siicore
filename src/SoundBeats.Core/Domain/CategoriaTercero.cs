using System;
using System.Collections.Generic;


namespace SoundBeats.Core.Domain
{
    public partial class CategoriaTercero
    {
        public CategoriaTercero()
        {
            Terceros = new HashSet<Terceros>();
        }

        public int IdCategoriaTercero { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Terceros> Terceros { get; set; }
    }
}

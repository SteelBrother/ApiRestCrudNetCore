using System;
using System.Collections.Generic;

#nullable disable

namespace TalyCap.Entities
{
    public partial class TipoLugarEntrega : Entity
    {
        public string Nombre { get; set; }

        public virtual ICollection<LugarEntrega> LugarEntregas { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace TalyCap.Entities
{
    public partial class TipoEnvio : Entity
    {
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace TalyCap.Entities
{
    public partial class Registro : Entity
    {

        public DateTime FechaRegistro { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace TalyCap.Entities
{
    public partial class TipoVehiculoEntrega : Entity
    {
        public string Nombre { get; set; }

        public virtual ICollection<VehiculoEntrega> VehiculoEntregas { get; set; }
    }
}

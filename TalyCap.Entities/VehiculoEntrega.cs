using System;
using System.Collections.Generic;

#nullable disable

namespace TalyCap.Entities
{
    public partial class VehiculoEntrega : Entity
    {
        
        public string Matricula { get; set; }
        public string NombreConductor { get; set; }
        public int IdTipoVehiculoEntrega { get; set; }
        public virtual TipoVehiculoEntrega TipoVehiculoEntrega { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}

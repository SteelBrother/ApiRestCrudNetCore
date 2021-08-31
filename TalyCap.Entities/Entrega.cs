using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalyCap.Entities
{
    public partial class Entrega : Entity
    {
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }

        
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<LugarEntrega> LugarEntrega { get; set; }
        public virtual VehiculoEntrega VehiculoEntrega { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalyCap.Entities
{
    public partial class Producto : Entity
    {
        
        public double PrecioEnvio { get; set; }

        [NotMapped]
        public int IdTipoEnvio { get; set; }
        [NotMapped]
        public int IdRegistro { get; set; }
        [NotMapped]
        public int IdEntrega { get; set; }
        public string DescripcionProducto { get; set; }

        public virtual Entrega Entrega { get; set; }
        public virtual Registro Registro { get; set; }
        public virtual TipoEnvio TipoEnvio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalyCap.Entities
{
    public partial class LugarEntrega : Entity
    {
        
        public string Direccion { get; set; }
        public int IdTipoLugarEntrega { get; set; }
        public TipoLugarEntrega TipoLugarEntrega { get; set; }
        public ICollection<Entrega> Entregas { get; set; }
    }
}

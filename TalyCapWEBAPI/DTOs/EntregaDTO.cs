using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapWEBAPI.DTOs
{
    public class EntregaDTO
    {
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }
        public int Cliente { get; set; }
        public int LugarEntrega { get; set; }
        public int VehiculoEntrega { get; set; }
        public int Productos { get; set; }
    }
}

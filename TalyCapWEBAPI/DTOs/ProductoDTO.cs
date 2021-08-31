using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapWEBAPI.DTOs
{
    public class ProductoDTO
    {
        public double PrecioEnvio { get; set; }
        public string DescripcionProducto { get; set; }
        public int Entrega { get; set; }
        public int Registro { get; set; }
        public int TipoEnvio { get; set; }
    }
}

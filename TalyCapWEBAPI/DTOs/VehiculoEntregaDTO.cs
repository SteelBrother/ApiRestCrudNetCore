using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapWEBAPI.DTOs
{
    public class VehiculoEntregaDTO
    {
        public string Matricula { get; set; }
        public string NombreConductor { get; set; }
        public int IdTipoVehiculoEntrega { get; set; }
    }
}

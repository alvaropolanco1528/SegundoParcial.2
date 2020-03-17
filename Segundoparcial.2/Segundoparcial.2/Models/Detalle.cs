
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Segundoparcial._2.Models
{
    public class Detalle
    {
        [Key]
        public int CasoId { get; set; }
        public int LlamadaId { get; set; }
        [Required(ErrorMessage = "Debes Agregar una Descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es necesario declarar una solucion")]
        public string Solucion { get; set; }
        public Detalle()
        {
            LlamadaId = 0;
            CasoId = 0;
            Descripcion = string.Empty;
           
        }
    }
}

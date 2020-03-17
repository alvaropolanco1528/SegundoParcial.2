using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Segundoparcial._2.Models
{
    public class Telefonos
    {
        [Key]

        public int LlamadaId { get; set; }
        [Required(ErrorMessage = "Es necesaria una descripcion")]

        public string Problema { get; set; }
        public string Solucion { get; set; }
        
        [ForeignKey("LlamadaId")]
        public List<Detalle> Detalles { get; set; }

        public Telefonos()
        {
            LlamadaId = 0;
            
            Problema = string.Empty;
            Solucion = string.Empty;
            Detalles = new List<Detalle>();
        }
    }
}

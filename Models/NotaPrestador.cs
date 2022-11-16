using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class NotaPrestador
    {
        public int NotaPrestadorId { get; set; }
        public float Avaliacao { get; set; }
        [ForeignKey("Prestador")]
        public int FkPrestador { get; set; }
        public Prestador Prestador { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class AcordoCancelado
    {
        public int AcordoCanceladoId { get; set; }
        public string? Justificativa { get; set; }
        [ForeignKey("Acordo")]
        public int AcordoFk { get; set; }
        public Acordo? Acordo { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class LocalDoPrestador
    {
        public int? LocalDoPrestadorId { get; set; }
        public string? Cidade { get; set; }
        [ForeignKey("Prestador")]
        public int PrestadorFk { get; set; }
        public virtual Prestador? Prestador { get; set; }
    }
}
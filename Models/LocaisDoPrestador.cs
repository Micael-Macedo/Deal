using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class LocaisDoPrestador
    {
        public int? LocaisDoPrestadorId { get; set; }
        public string? Cidade;
        [ForeignKey("Prestador")]
        public int PrestadorFk { get; set; }
        public virtual Prestador? Prestador { get; set; }
    }
}
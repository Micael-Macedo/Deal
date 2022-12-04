using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class AreasDeAtuacaoDoPrestador
    {
        public int AreasDeAtuacaoDoPrestadorId { get; set; }
        [ForeignKey("Prestador")]
        public int? FkPrestador { get; set; }
        public virtual Prestador? Prestador { get; set; }
        [ForeignKey("AreaAtuacao")]
        public int? FkAreaAtuacao { get; set; }
        public virtual AreaAtuacao? AreaAtuacao { get; set; }
    }
}
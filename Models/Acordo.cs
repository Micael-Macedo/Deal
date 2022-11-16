using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Acordo
    {   
        
        public int AcordoId { get; set; }
        [ForeignKey("Servico")]
        public int? FkServico { get; set; }
        public virtual Servico Servico { get; set; }
        [ForeignKey("Cliente")]
        public int? FkCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("Prestador")]
        public int? FkPrestador { get; set; }
        public virtual Prestador Prestador { get; set; }   

    }
}
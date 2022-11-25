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
        public virtual Servico? Servico { get; set; }
        public float? NotaCliente { get; set; }
        public float? NotaPrestador { get; set; }
          

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class NotaCliente
    {
        public int NotaClienteId { get; set; }
        public float Avaliacao { get; set; }
        [ForeignKey("Cliente")]
        public int FkCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
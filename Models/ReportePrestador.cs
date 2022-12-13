using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class ReportePrestador
    {
        public int ReportePrestadorId { get; set; }
        public string? Motivo { get; set; }
        [ForeignKey("Prestador")]
        public int FkPrestador { get; set; }
        public Prestador? Prestador { get; set; }
        [ForeignKey("Cliente")]
        public int FkCliente { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey("Servico")]
        public int FkServico { get; set; }
        public Servico? Servico { get; set; }
    }
}
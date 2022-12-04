using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deal.Models
{
    public class Certificado
    {
        public int CertificadoId { get; set; }
        public string? CertificadoFotoPortfolio { get; set; }
        [ForeignKey("Portfolio")]
        public int FkPortfolio;
        public virtual Portfolio? Portfolio { get; set; }
        
    }
}
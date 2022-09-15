using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Descricao { get; set; }
        public ICollection<string> Fotos { get; set; }
        public string ExperienciaProfissional { get; set; }
        public ICollection<string> Videos { get; set; }
        public ICollection<string> Certificado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string? Apresentacao { get; set; }
        public string? Linkedin {get; set; }
        public string? Site {get; set; }
        public ICollection<Foto>? Fotos { get; set; }
        public string? ExperienciaProfissional { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Certificado>? Certificados { get; set; }
    }
}
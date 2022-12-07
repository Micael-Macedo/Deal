using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class UsuarioPrestador
    {
        public Prestador? Prestador { get; set; }
        public List<Servico>? Servicos { get; set; }
        public Servico? Servico { get; set; }
        public List<Acordo>? Acordos { get; set; }
        public Acordo? Acordo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deal;

namespace Deal
{
    public class Servico
    {
        public Cliente cliente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cep { get; set; }
        public string Categoria { get; set; }
        public string Status { get; set; }
    }
}
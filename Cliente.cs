using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC
{
    public class Cliente : Usuario
    {
        public ICollection<Servico> servicos MyProperty { get; set; }
    }
}
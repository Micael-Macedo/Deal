using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deal;

namespace Deal
{
    public class Cliente : Usuario
    {
        public ICollection<Servico> servicos { get; set; }
    }
}
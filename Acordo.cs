using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal
{
    public class Acordo
    {   
        public int IdAcordo { get; set; }
        public Servico Servico { get; set; }
        public Cliente Cliente { get; set; }
        public Prestador Prestador { get; set; }   

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class NovaAreaAtuacao
    {
        public string? NovaAreaAtuacaoId { get; set; }
        public string? AreaAtuacao { get; set; }
        public bool isOnline { get; set; }
        public bool isPresencial { get; set; }
    }
}
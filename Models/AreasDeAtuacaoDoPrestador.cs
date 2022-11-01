using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deal.Models
{
    public class AreasDeAtuacaoDoPrestador
    {
        public int AreasDeAtuacaoDoPrestadorId { get; set; }
        [ForeignKey("Prestador")]
        public int FkPrestador;
        public Prestador Prestador { get; set; }
        [ForeignKey("AreaAtuacao")]
        public int FkAreaAtuacao;
        public AreaAtuacao AreaAtuacao { get; set; }
    }
}
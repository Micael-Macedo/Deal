using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Deal;

namespace Deal.Models
{
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }
        [ForeignKey("Cliente")]
        public int FkCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cep { get; set; }
        public string Categoria { get; set; }
        public string Status { get; set; }
    }
}
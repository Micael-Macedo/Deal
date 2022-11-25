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
        public int ServicoId { get; set; }
        [ForeignKey("Cliente")]
        public int? FkCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        [ForeignKey("Categoria")]
        public int? FkCategoria { get; set; }
        public virtual AreaAtuacao? Categoria { get; set; }
        [ForeignKey("Prestador")]
        public int? FkPrestador { get; set; }
        public virtual Prestador? Prestador { get; set; }
        public string? Status { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

        public bool ClienteCancelaServico(){
            this.Cliente.ServicosCancelados++;
            if(this.Cliente.ServicosCancelados == 5){
                this.Cliente.ServicosCancelados = 0;
                return true;
            }
            return false;
        }
    }
}
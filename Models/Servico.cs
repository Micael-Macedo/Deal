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
        public Servico()
        {
            IsDisponivel = true;
        }
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
        public bool IsDisponivel { get; set; }
        public bool IsAcordoFeito { get; set; }
        public void PrestadorRecusaServico()
        {
            Status = "Prestador Recusou o Serviço";
            IsDisponivel = true;
            FkPrestador = null;
        }
        public void ClienteRecusaServico()
        {
            Status = "Prestador foi recusado";
            IsDisponivel = true;
            FkPrestador = null;
        }
        public void AcordoAceito()
        {
            Status = "Acordo Feito";
            IsAcordoFeito = true;
            IsDisponivel = false;
        }
    }
}
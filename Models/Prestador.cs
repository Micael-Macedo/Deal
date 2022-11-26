using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Deal.Models
{
    public class Prestador
    {
        public int PrestadorId { get; set; }
        public string? FotoPrestador { get; set; }
        [ForeignKey("Portfolio")]
        public int? FkPortfolio { get; set; }
        public Portfolio? Portfolio { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public int Idade { get; set; }
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        private float pontuacao { get; set; }
        public ICollection<NotaPrestador>? NotasDoPrestador { get; set; } //Criar método média, ArrayNotas sempre começa com 5.0 de nota
        public virtual ICollection<AreaAtuacao>? AreasAtuacao { get; set; }
        public ICollection<AreasDeAtuacaoDoPrestador>? AreasDeAtuacaoDoPrestador { get; set; }
        public int QtdServicoRealizados { get; set; }

        public float Pontuacao
        {
            get
            {
                pontuacao = MediaNota();
                return pontuacao;
            }
            set{
                pontuacao = MediaNota();
            }
        }
        public float MediaNota()
        {
            float TotalNotas = 0;
            foreach (var Nota in NotasDoPrestador)
            {
                TotalNotas += Nota.Avaliacao;
            }
            float MediaAvaliacao = TotalNotas / NotasDoPrestador.Count;
            return MediaAvaliacao;
        }
    }
}
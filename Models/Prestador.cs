using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Deal.Models
{
    public class Prestador
    {
        public Prestador(){
            Pontuacao = 5;
        }
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
        public float Pontuacao { get; set; }
        public ICollection<NotaPrestador>? NotasDoPrestador { get; set; } //Criar método média, ArrayNotas sempre começa com 5.0 de nota
        public ICollection<AreaAtuacao>? AreasAtuacao { get; set; }
        public ICollection<AreasDeAtuacaoDoPrestador>? AreasDeAtuacaoDoPrestador { get; set; }
        public int QtdServicoRealizados { get; set; }
        public int AcordosCancelados { get; set; }

        public float MediaNota()
        {
            if (NotasDoPrestador == null || NotasDoPrestador.Count == 0)
            {
                if(AcordosCancelados % 5 == 0){
                    for(int i=0; i < AcordosCancelados/5; i++){
                        NotaPrestador notaPrestador = new NotaPrestador();
                        notaPrestador.Avaliacao = 1;
                        NotasDoPrestador.Add(notaPrestador);
                    }
                }
                return Pontuacao;
            }
            else
            {
                if(AcordosCancelados % 5 == 0){
                    for(int i=0; i < AcordosCancelados/5; i++){
                        NotaPrestador notaPrestador = new NotaPrestador();
                        notaPrestador.Avaliacao = 1;
                        NotasDoPrestador.Add(notaPrestador);
                    }
                }
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
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Deal.Models
{
    public class Prestador
    {
        public Prestador()
        {
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
        public double Pontuacao { get; set; }
        public ICollection<NotaPrestador>? NotasDoPrestador { get; set; } //Criar método média, ArrayNotas sempre começa com 5.0 de nota
        public ICollection<AreaAtuacao>? AreasAtuacao { get; set; }
        public ICollection<AreasDeAtuacaoDoPrestador>? AreasDeAtuacaoDoPrestador { get; set; }
        public ICollection<LocalDoPrestador>? LocaisDoPrestador { get; set; }
        public int QtdServicoRealizados { get; set; }
        public int AcordosCancelados { get; set; }
        public int QtdContaReportada { get; set; }

        public double MediaNota()
        {
            double MediaAvaliacao;
            if (NotasDoPrestador == null || NotasDoPrestador.Count == 0)
            {
                if (VerificarAcordosCancelados())
                {
                    double PontuacaoPenalizada = AcordosCancelados / 5;
                    MediaAvaliacao = (5 + PontuacaoPenalizada) / (PontuacaoPenalizada + 1);
                    return Math.Round(MediaAvaliacao, 2);
                }
                else
                {
                    return Math.Round(Pontuacao, 2);
                }
            }
            else
            {
                double TotalNotas = 0;
                foreach (var Nota in NotasDoPrestador)
                {
                    TotalNotas += Nota.Avaliacao;
                }
                if (VerificarAcordosCancelados())
                {
                    double PontuacaoPenalizada = AcordosCancelados / 5;
                    MediaAvaliacao = (TotalNotas + PontuacaoPenalizada + 5) / (NotasDoPrestador.Count + PontuacaoPenalizada + 1);
                }
                else
                {
                    MediaAvaliacao = TotalNotas / NotasDoPrestador.Count;
                }
                return Math.Round(MediaAvaliacao, 2);
            }
        }
        public bool VerificarAcordosCancelados()
        {
            if (AcordosCancelados % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
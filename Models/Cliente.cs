using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Deal;

namespace Deal.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Pontuacao = 5;
        }
        public int ClienteId { get; set; }
        public string? FotoUsuario { get; set; }
        public ICollection<Servico>? Servicos { get; set; }
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF")]
        public string? Cpf { get; set; }
        public int Idade { get; set; }
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public double Pontuacao { get; set; }
        public ICollection<NotaCliente>? NotasDoCliente { get; set; }
        public int QtdAcordoRealizados { get; set; }

        public int AcordosCancelados { get; set; }
        public int QtdContaReportada { get; set; }

        public double MediaNota()
        {
            double MediaAvaliacao;
            if (NotasDoCliente == null || NotasDoCliente.Count == 0)
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
                foreach (var Nota in NotasDoCliente)
                {
                    TotalNotas += Nota.Avaliacao;
                }
                if (VerificarAcordosCancelados())
                {
                    double PontuacaoPenalizada = AcordosCancelados / 5;
                    MediaAvaliacao = (TotalNotas + PontuacaoPenalizada + 5) / (NotasDoCliente.Count + PontuacaoPenalizada + 1);
                }
                else
                {
                    MediaAvaliacao = TotalNotas / NotasDoCliente.Count;
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
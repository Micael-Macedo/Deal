using System;
using System.Collections.Generic;
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
        public string? Cpf { get; set; }
        public int Idade { get; set; }
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public float Pontuacao { get; set; }
        public ICollection<NotaCliente>? NotasDoCliente { get; set; }
        public int QtdAcordoRealizados { get; set; }

        public int AcordosCancelados { get; set; }

        public float MediaNota()
        {

            if (NotasDoCliente == null || NotasDoCliente.Count == 0 )
            {
                return Pontuacao;
            }
            else
            {
                if (AcordosCancelados % 5 == 0)
                {
                    for (int i = 0; i < AcordosCancelados / 5; i++)
                    {
                        NotaCliente notaCliente = new NotaCliente();
                        notaCliente.Avaliacao = 1;
                        NotasDoCliente.Add(notaCliente);
                    }
                }
                float TotalNotas = 0;
                foreach (var Nota in NotasDoCliente)
                {
                    TotalNotas += Nota.Avaliacao;
                }
                float MediaAvaliacao = TotalNotas / NotasDoCliente.Count;
                return MediaAvaliacao;
            }
        }
        public bool PenalizarCliente()
        {
            if (AcordosCancelados % 5 == 0)
            {
                for (int i = 0; i < AcordosCancelados / 5; i++)
                {
                    NotaCliente notaCliente = new NotaCliente();
                    notaCliente.Avaliacao = 1;
                    NotasDoCliente.Add(notaCliente);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
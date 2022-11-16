using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deal;

namespace Deal.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string FotoUsuario { get; set; }
        public ICollection<Servico>? Servicos { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public ICollection<NotaCliente>? Notas { get; set; }
        public int QtdAcordoRealizados { get; set; } 
        public int ServicosCancelados { get; set; }

        public float MediaNota()
        {
            float TotalNotas = 0;
            foreach (var Nota in Notas)
            {
                TotalNotas += Nota.Avaliacao;
            }
            return TotalNotas / Notas.Count;
        }
    }
}
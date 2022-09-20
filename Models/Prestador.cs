using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Deal.Models
{
    public class Prestador
    {
        public int PrestadorId { get; set; }
        public Portfolio Portfolio { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public ICollection<Nota> Notas { get; set; } //Criar método média, ArrayNotas sempre começa com 5.0 de nota
        public int QtdServicoRealizados { get; set; }

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
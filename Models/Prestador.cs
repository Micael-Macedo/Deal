using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal
{
    public class Prestador
    {
        public int IdPrestador { get; set; }
        public Portfolio Portfolio { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public float Pontuacao { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public float Nota { get; set; } // Nota começa com valor 5
        public int QtdServicoRealizados { get; set; }
    }
}
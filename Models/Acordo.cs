using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Acordo
    {

        public int AcordoId { get; set; }
        [ForeignKey("Servico")]
        public int? FkServico { get; set; }
        public virtual Servico? Servico { get; set; }
        public float? NotaCliente { get; set; }
        public float? NotaPrestador { get; set; }
        private bool clienteFinalizaAcordo;
        private bool prestadorFinalizaAcordo;
        public bool ClienteFinalizaAcordo
        {
            get
            {
                return clienteFinalizaAcordo;
            }
            set
            {
                clienteFinalizaAcordo = value;
                VerificarSeAcordoFoiFinalizado();
            }
        }
        public bool PrestadorFinalizaAcordo
        {
            get
            {
                return prestadorFinalizaAcordo;
            }
            set
            {
                prestadorFinalizaAcordo = value;
                VerificarSeAcordoFoiFinalizado();
            }
        }
        public bool VerificarSeAcordoFoiFinalizado()
        {
            if (clienteFinalizaAcordo == true && prestadorFinalizaAcordo == true)
            {
                acordoFinalizado = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool acordoFinalizado;
        public bool AcordoFinalizado
        {
            get
            {
                return acordoFinalizado;
            }
            set
            {
                acordoFinalizado = value;
            }
        }
    }
}
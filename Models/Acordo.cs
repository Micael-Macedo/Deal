using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Acordo
    {   
        public int AcordoId { get; set; }
        public Servico Servico { get; set; }
        public Cliente Cliente { get; set; }
        public Prestador Prestador { get; set; }   

        public void FecharAcordo(Cliente Prestador){
            //Esse metodo que puxa outro, pode ficar aqui ou tem que ser no controller?
            if ConfirmarAcordo(true){
                Cliente = Cliente;
                Prestador = Prestador;
                Servico.Status = "Confirmado";
            }
        }

    }
}
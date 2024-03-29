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
        public bool AvaliouCliente { get; set; }
        private bool acordoFinalizado;
        public bool AvaliouPrestador { get; set; }
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
                return true;
            }
            else
            {
                return false;
            }
        }
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
        public bool AvaliarCliente(){
            if(AvaliouCliente != true){
                AvaliouCliente = true;
                return true;
            }else{
                return false;
            }
        }
        public bool AvaliarPrestador(){
            if(AvaliouPrestador != true){
                AvaliouPrestador = true;
                return true;
            }else{
                return false;
            }
        }
        public bool PrestadorFinalizouAcordo(){
            if(PrestadorFinalizaAcordo != true){
                prestadorFinalizaAcordo = true;
                return true;
            }else{
                return false;
            }
        }
        public bool ClienteFinalizouAcordo(){
            if(ClienteFinalizaAcordo != true){
                ClienteFinalizaAcordo = true;
                return true;
            }else{
                return false;
            }
        }
        public void CancelarAcordo(){
            Servico.Cliente.AcordosCancelados++;
            Servico.Cliente.MediaNota();
        }
        public bool EncerrarAcordo(){
            if(Servico.Prestador != null && Servico != null){
                Servico.Prestador.AcordosCancelados++;
                Servico.Status = "Prestador Cancelou o acordo";
                Servico.IsDisponivel = true;
                Servico.IsAcordoFeito = false;
                Servico.Prestador.MediaNota();
                return true;
            }else{
                return false;
            }
        }
        public bool ReportarCliente(){
            if(Servico.Cliente != null && Servico != null){
                Servico.Status = "Prestador Cancelou o acordo";
                Servico.IsDisponivel = true;
                Servico.IsAcordoFeito = false;
                Servico.Cliente.QtdContaReportada++;
                Servico.FkPrestador = null;
                return true;
            }else{
                return false;
            }
        }
        public bool ReportarPrestador(){
            if(Servico.Prestador != null && Servico != null){
                Servico.Status = "Prestador reportado";
                Servico.IsDisponivel = true;
                Servico.IsAcordoFeito = false;
                Servico.Prestador.QtdContaReportada++;
                Servico.FkPrestador = null;
                return true;
            }else{
                return false;
            }
        }
        public bool FinalizarAcordo(){
            if(Servico.Cliente != null && Servico.Prestador != null){
                Servico.Cliente.QtdAcordoRealizados++;
                Servico.Prestador.QtdServicoRealizados++;
                acordoFinalizado = true;
                return true;
            }else{
                return false;
            }
        }
    }
}
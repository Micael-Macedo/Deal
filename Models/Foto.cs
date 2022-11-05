using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        public string FotoPrestador { get; set; }
        [ForeignKey("Portfolio")]
        public int? FkPortfolio { get; set; }
        public virtual Portfolio Portifolio { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        public string FotoPortfolio { get; set; }
        [ForeignKey("Portfolio")]
        public int FkPortfolio;
         public Portfolio Portfolio { get; set; }
    }
}
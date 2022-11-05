using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoPrestador { get; set; }
        [ForeignKey("Portfolio")]
        public int? FkPortfolio { get; set; }
        public virtual Portfolio Portifolio { get; set; }
    }
}
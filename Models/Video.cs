using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deal.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoPortfolio { get; set; }
        [ForeignKey("Portfolio")]
        public int FkPortfolio;
        public Portfolio Portfolio { get; set; }
    }
}
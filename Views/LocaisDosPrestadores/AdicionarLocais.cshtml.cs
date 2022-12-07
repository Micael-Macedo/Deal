using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Deal.Views.LocaisDosPrestadores
{
    public class AdicionarLocais : PageModel
    {
        private readonly ILogger<AdicionarLocais> _logger;

        public AdicionarLocais(ILogger<AdicionarLocais> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
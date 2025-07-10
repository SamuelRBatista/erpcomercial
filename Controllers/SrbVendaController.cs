using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbVendaController
    {
        private readonly SrbVendaService _vendaService;

        public SrbVendaController()
        {
            _vendaService = new SrbVendaService();
        }

        public void AdicionarVenda(SrbVenda venda)
        {
            _vendaService.AdicionarVenda(venda);
        }



    }

  



}

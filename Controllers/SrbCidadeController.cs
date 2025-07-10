using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbCidadeController
    {
        private readonly SrbCidadeService _cidadeService;

        public SrbCidadeController()
        {
            _cidadeService = new SrbCidadeService();
        }

        public List<SrbCidade> ObterCidade()
        {
            return _cidadeService.ObterCidades();
        }
    }
}

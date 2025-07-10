using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbEstadoController
    {
        private readonly SrbEstadoService _estadoService;

        public SrbEstadoController()
        {
            _estadoService = new SrbEstadoService();
        }

        public List<SrbEstado> ObterEstado()
        {
            return _estadoService.ObterEstados();
        }
    }
}

using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbCategoriaController
    {
        private readonly SrbCategoriaService _categoriaService;

        public SrbCategoriaController()
        {
            _categoriaService = new SrbCategoriaService();
        }

        public List<SrbCategoria> ObterCategoria()
        {
           return _categoriaService.ObterCategorias();
        }
      
    }
}

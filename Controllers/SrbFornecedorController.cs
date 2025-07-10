using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbFornecedorController
    {
        private readonly SrbFornecedorService _fornecedorService;

        public SrbFornecedorController()
        {
            _fornecedorService = new SrbFornecedorService();   
        }

        public List<SrbFornecedor> ObterFornecedor()
        {
            return _fornecedorService.ObterFornecedor();
        }
        public void AdicionarFornecedor(SrbFornecedor fornecedor)
        {
            _fornecedorService.AdicionarFornecedor(fornecedor);

        }       
        public void AtualizarFornecedor(SrbFornecedor fornecedor)
        {
            _fornecedorService.AtualizarFornecedor(fornecedor);
        }
        public void RemoverFornecedor(int id)
        {
            _fornecedorService.RemoverFornecedor(id);
        }

        public List<SrbFornecedor> BuscarFornecedorPorCnpj(string cnpj)
        {
            return _fornecedorService.BuscarFornecedorPorCnpj(cnpj);
        }
        public List<SrbFornecedor> BuscaFornecedorPorNome(string nome)
        {
            return _fornecedorService.BuscaFornecedorPorNome(nome);
        }
        public List<SrbFornecedor> BuscarFornecedorPorRazaoSocial(string nomeRazao)
        {
            return _fornecedorService.BuscaFornecedorPorRazaoSocial(nomeRazao);
        }
    }
}

using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbProdutoController
    {
        private readonly SrbProdutoService _produtoService;

        public SrbProdutoController()
        {
            _produtoService = new SrbProdutoService();
        }

        public void AdicionarProduto(SrbProduto produto)
        {
            _produtoService.AdicionarProduto(produto);
        }
        public void AtualizarProduto(SrbProduto produto)
        {
            _produtoService.AtualizarProduto(produto);
        }
        public void AtualizarQuantidadeProduto(int codigo, int novaQuantidade)
        {
            _produtoService.AtualizarQuantidadeProduto(codigo, novaQuantidade);
        }
        public List<SrbProduto> ObterProdutos()
        {
            return _produtoService.ObterProdutos();
        }        
        public void RemoverProduto(int id)
        {
            _produtoService.RemoverProduto(id);
        }
        public List<SrbProduto> BuscarProdutoPorEan(string ean)
        {
            return _produtoService.BuscarProdutoPorEan(ean);
        }
        public SrbProduto BuscarProdutoPorId(int id)
        {
            return _produtoService.BuscarProdutoPorId(id);
        }
        public List<SrbProduto> BuscarProdutoPorCodigo(int codigo)
        {
            return _produtoService.BuscarProdutoPorCodigo(codigo);
        }
        public List<SrbProduto> BuscarProdutoPorNome(string nome)
        {
            return _produtoService.BuscarProdutoPorNome(nome);
        }       
    }
}

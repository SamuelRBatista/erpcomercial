using SRB_COMERCIALPDV.Controllers;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SRB_COMERCIALPDV.Services
{
    public class NotaFiscalService
    {
        private SrbProdutoController produtoController;

        public NotaFiscalService()
        {
            produtoController = new SrbProdutoController();
        }
        public List<SrbProduto> ImportarProdutosDoXml(string caminhoArquivoXml)
        {
            List<SrbProduto> produtos = new List<SrbProduto>();

            XmlDocument doc = new XmlDocument();
            doc.Load(caminhoArquivoXml);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");

            XmlNodeList itens = doc.SelectNodes("//nfe:det", ns);

            foreach (XmlNode item in itens)
            {
                try
                {
                    string cod = item.SelectSingleNode("nfe:prod/nfe:cProd", ns)?.InnerText;
                    string ean = item.SelectSingleNode("nfe:prod/nfe:cEAN", ns)?.InnerText;
                    string nome = item.SelectSingleNode("nfe:prod/nfe:xProd", ns)?.InnerText;
                    string ncm = item.SelectSingleNode("nfe:prod/nfe:NCM", ns)?.InnerText;
                    string cest = item.SelectSingleNode("nfe:prod/nfe:CEST", ns)?.InnerText;
                    string precoStr = item.SelectSingleNode("nfe:prod/nfe:vUnCom", ns)?.InnerText;
                    string quantidadeStr = item.SelectSingleNode("nfe:prod/nfe:qCom", ns)?.InnerText;

                    decimal preco = decimal.TryParse(precoStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : 0;
                    int quantidade = int.TryParse(Convert.ToDecimal(quantidadeStr, CultureInfo.InvariantCulture).ToString(), out var q) ? q : 0;


                    SrbProduto produto = new SrbProduto
                    {
                        SrbCod = cod,
                        SrbEan = ean,
                        SrbNome = nome,
                        SrbDescricao = nome,
                        SrbPreco = preco,
                        SrbQuantidade = quantidade,
                        SrbValidade = DateTime.Today.AddYears(1),
                        SrbNcm = ncm,
                        SrbCest = cest,
                        SrbCategoriaId = 1
                    };

                    produtoController.AdicionarProduto(produto);
                }
                catch (Exception ex)
                {
                  
                    Console.WriteLine($"Erro ao importar produto: {ex.Message}");
                }
            }

            return produtos;
        }
    }
}

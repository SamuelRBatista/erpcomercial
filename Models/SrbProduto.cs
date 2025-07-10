using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Models
{
    public class SrbProduto
    {
        public int SrbID { get; set; }
        public string SrbCod { get; set; }
        public string SrbEan { get; set; }
        public string SrbNome { get; set; }
        public string SrbDescricao { get; set; }
        public decimal SrbPreco { get; set; }
        public int SrbQuantidade { get; set; }
        public DateTime SrbValidade { get; set; }
        public string SrbNcm { get; set; }
        public string SrbCest { get; set; }
        public int SrbCategoriaId { get; set; }
        public string SrbNomeCategoria { get; set; } // Propriedade para o nome da categoria

    }
}

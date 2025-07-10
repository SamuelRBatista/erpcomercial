using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Models
{
    public class 
        
        SrbVenda
    {
        public int SrbVendaId { get; set; }       
        public int SrbQuantidade { get; set; }
        public decimal SrbPrecoUnitario { get; set; }
        public DateTime SrbDataVenda { get; set; }
        public decimal SrbValorPago { get; set; }
        public decimal SrbTroco { get; set; }
    }
}

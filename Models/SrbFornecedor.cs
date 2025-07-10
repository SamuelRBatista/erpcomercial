using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Models
{
    public class SrbFornecedor
    {
        public int SrbID { get; set; } 
        
        public string SrbCnpj { get; set; } 
        public string SrbNome { get; set; } 
        public string SrbRazaoSocial { get; set; }  
        public string SrbEndereco { get; set; }
        public string SrbBairro { get; set; }
        public string SrbCep {  get; set; } 
        public string SrbTelefone { get; set; } 
        public string SrbCelular {get; set; }
        public string SrbEmail { get; set; }
        public int SrbCidadeId { get; set; }
        public string SrbNomeCidade { get; set; }
        public int SrbEstadoId { get; set; }
        public string SrbNomeEstado { get; set; }

        
    }
}

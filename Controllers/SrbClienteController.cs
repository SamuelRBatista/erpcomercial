using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Controllers
{
    public class SrbClienteController
    {
        private readonly SrbClienteService _clienteService;

        public SrbClienteController()
        {
            _clienteService = new SrbClienteService();   
        }

        public List<SrbCliente> ObterCliente()
        {
            return _clienteService.ObterCliente();
        }
        public void AdicionarCliente(SrbCliente cliente)
        {
            _clienteService.AdicionarCliente(cliente);

        }
       
        public void AtualizarCliente(SrbCliente cliente)
        {
            _clienteService.AtualizarCliente(cliente);
        }

        public void RemoverCliente(int id)
        {
            _clienteService.RemoverCliente(id);
        }

        public List<SrbCliente> BuscarClientePorCpf(string cpf)
        {
            return _clienteService.BuscarClientePorCpf(cpf);
        }

        public List<SrbCliente> BuscarClientePorNome(string nome)
        {
            return _clienteService.BuscarClientePorNome(nome);
        }

        public List<SrbCliente> BuscarClientePorCep(string cep)
        {
            return _clienteService.BuscarClientePorCep(cep);
        }

    }
}

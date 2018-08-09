using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cliente.WebApi.DataAccess;
using Cliente.WebApi.Models;

namespace Cliente.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public void Atualizar(Models.Cliente cliente)
        {
            _context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
        }

        public Models.Cliente BuscarPorId(int Id)
        {
            return _context.Clientes.Include("Enderecos").ToList().Find(c => c.ClienteId == Id);
        }

        public void Cadastrar(Models.Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public List<Models.Cliente> Listar()
        {
            return _context.Clientes.Include("Enderecos").ToList();
        }

        public void Remover(int Id)
        {
            var cliente = BuscarPorId(Id);
            _context.Clientes.Remove(cliente);
        }
    }
}
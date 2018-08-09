using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cliente.WebApi.DataAccess;
using Cliente.WebApi.Models;

namespace Cliente.WebApi.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private ClienteContext _context;

        public EnderecoRepository(ClienteContext context)
        {
            _context = context;
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Entry(endereco).State = System.Data.Entity.EntityState.Modified;
        }

        public Endereco BuscarPorId(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.Include("Cliente").ToList();
        }

        public List<Endereco> ListarPorCliente(int CodigoCliente)
        {
            return _context.Enderecos.Where(e => e.ClienteId == CodigoCliente).ToList();
        }

        public void Remover(int id)
        {
            var endereco = BuscarPorId(id);
            _context.Enderecos.Remove(endereco);
        }
    }
}
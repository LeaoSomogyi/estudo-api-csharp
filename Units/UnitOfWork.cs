using Cliente.WebApi.DataAccess;
using Cliente.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.WebApi.Units
{
    public class UnitOfWork : IDisposable
    {
        private ClienteContext _context = new ClienteContext();

        private IClienteRepository _clienteRepository;

        public IClienteRepository ClienteRepository
        {
            get
            {
                if (_clienteRepository == null)
                {
                    _clienteRepository = new ClienteRepository(_context);
                }
                return _clienteRepository;
            }
        }

        private IEnderecoRepository _enderecoRepository;

        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                if (_enderecoRepository == null)
                {
                    _enderecoRepository = new EnderecoRepository(_context);
                }
                return _enderecoRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges(); 
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
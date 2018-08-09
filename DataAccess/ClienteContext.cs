using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cliente.WebApi.DataAccess
{
    public class ClienteContext : DbContext
    {
        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Models.Endereco> Enderecos { get; set; }
    }
}
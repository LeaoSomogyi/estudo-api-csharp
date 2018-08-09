using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.WebApi.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Models.Cliente cliente);
        List<Models.Cliente> Listar();
        Models.Cliente BuscarPorId(int Id);
        void Atualizar(Models.Cliente cliente);
        void Remover(int Id);
    }
}

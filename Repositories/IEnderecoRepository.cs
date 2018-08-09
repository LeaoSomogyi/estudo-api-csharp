using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.WebApi.Models;

namespace Cliente.WebApi.Repositories
{
    public interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);
        List<Endereco> Listar();
        Endereco BuscarPorId(int id);
        void Atualizar(Endereco endereco);
        void Remover(int id);
        List<Endereco> ListarPorCliente(int CodigoCliente);
    }
}

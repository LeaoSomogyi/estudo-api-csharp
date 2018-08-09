using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model = Cliente.WebApi.Models;

namespace Cliente.WebApi.DTO
{
    [JsonObject("cliente")]
    public class Cliente
    {
        [JsonProperty("codigo")]
        public int ClienteId { get; set; }

        [JsonProperty("nome")]
        public String Nome { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("data_nascimento")]
        public string DataNascimento { get; set; }

        [JsonProperty("ativo")]
        public bool IsAtivo { get; set; }

        //Relacionamento Um para Muitos
        [JsonProperty("lista_endereco")]
        public List<Endereco> Enderecos { get; set; }

        public Cliente()
        {

        }

        public Cliente(Model.Cliente cliente)
        {
            this.ClienteId = cliente.ClienteId;
            this.Nome = cliente.Nome;
            this.Email = cliente.Email;
            this.DataNascimento = cliente.DataNascimento.ToString("dd-MM-yyyy hh:mm:ss");
            this.IsAtivo = cliente.IsAtivo;

            if (cliente.Enderecos != null && cliente.Enderecos.Count > 0)
            {
                this.Enderecos = cliente.Enderecos.Select(e => new Endereco(e)).ToList();
            }
        }

        public Model.Cliente Transfer()
        {
            return new Model.Cliente()
            {
                ClienteId = this.ClienteId,
                Nome = this.Nome,
                Email = this.Email,
                DataNascimento = Convert.ToDateTime(this.DataNascimento),
                IsAtivo = this.IsAtivo,
                Enderecos = this.Enderecos.Count > 0 ? this.Enderecos.Select(e => e.Transfer()).ToList() : null
            };
        }
    }
}
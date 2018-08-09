using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model = Cliente.WebApi.Models;

namespace Cliente.WebApi.DTO
{
    [JsonObject("endereco")]
    public class Endereco
    {
        [JsonProperty("codigo")]
        public int EnderecoId { get; set; }

        [JsonProperty("logradouro")]
        public String Logradouro { get; set; }

        [JsonProperty("complemento")]
        public String Complemento { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("ativo")]
        public bool IsAtivo { get; set; }

        [JsonProperty("cliente_codigo")]
        public int ClienteId { get; set; }

        public Endereco()
        {

        }

        public Endereco(Model.Endereco endereco)
        {
            this.EnderecoId = endereco.EnderecoId;
            this.Logradouro = endereco.Logradouro;
            this.Complemento = endereco.Complemento;
            this.Numero = endereco.Numero;
            this.IsAtivo = endereco.IsAtivo;
            this.ClienteId = endereco.ClienteId;
        }

        public Model.Endereco Transfer()
        {
            return new Model.Endereco()
            {
                EnderecoId = this.EnderecoId,
                Logradouro = this.Logradouro,
                Complemento = this.Complemento,
                Numero = this.Numero,
                IsAtivo = this.IsAtivo,
                ClienteId = this.ClienteId
            };
        }
    }
}
using Cliente.WebApi.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cliente.WebApi.Models;
using System.Web.Http.Cors;

namespace Cliente.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EnderecoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public List<DTO.Endereco> Get()
        {
            return _unit.EnderecoRepository.Listar().Select(e => new DTO.Endereco(e)).ToList();
        }

        [HttpGet]
        public DTO.Endereco Get(int id)
        {
            return new DTO.Endereco(_unit.EnderecoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public HttpResponseMessage Post(DTO.Endereco endereco)
        {
            _unit.EnderecoRepository.Cadastrar(endereco.Transfer());
            _unit.Salvar();
            return Request.CreateResponse<DTO.Endereco>(HttpStatusCode.OK, endereco);
        }

        [HttpPut]
        public HttpResponseMessage Put(DTO.Endereco endereco)
        {
            _unit.EnderecoRepository.Atualizar(endereco.Transfer());
            _unit.Salvar();
            return Request.CreateResponse<DTO.Endereco>(HttpStatusCode.OK, endereco);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _unit.EnderecoRepository.Remover(id);
            _unit.Salvar();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("GET")]
        [Route("api/Endereco/ListarPorCliente/{id}")]
        public List<DTO.Endereco> ListarPorCliente(int id)
        {
            return _unit.EnderecoRepository.ListarPorCliente(id).Select(e => new DTO.Endereco(e)).ToList();
        }
    }
}

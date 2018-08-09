using Cliente.WebApi.Models;
using DTO = Cliente.WebApi.DTO;
using Cliente.WebApi.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace Cliente.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ClienteController : System.Web.Http.ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        [ActionName("Listar")]
        public List<DTO.Cliente> Get()
        {
            return _unit.ClienteRepository.Listar().Select(c => new DTO.Cliente(c)).ToList();
        }

        [HttpGet]
        [ActionName("BuscarPorID")]
        public DTO.Cliente Get(int id)
        {
            return new DTO.Cliente(_unit.ClienteRepository.BuscarPorId(id));
        }

        [HttpPost]
        public System.Net.Http.HttpResponseMessage Post(DTO.Cliente cliente)
        {
            _unit.ClienteRepository.Cadastrar(cliente.Transfer());

            _unit.Salvar();

            return Request.CreateResponse<DTO.Cliente>(HttpStatusCode.OK, cliente);
        }

        [HttpPut]
        public HttpResponseMessage Put(DTO.Cliente cliente)
        {
            _unit.ClienteRepository.Atualizar(cliente.Transfer());

            _unit.Salvar();
            return Request.CreateResponse<DTO.Cliente>(HttpStatusCode.OK, cliente);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _unit.ClienteRepository.Remover(id);
            _unit.Salvar();
            return Request.CreateResponse(HttpStatusCode.OK);
        }        

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}
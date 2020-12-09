using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous.Api.NoSQL.Domains;
using Nyous.Api.NoSQL.Interfaces.Repositories;
using Nyous.Api.NoSQL.Repositories;

namespace Nyous.Api.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventoRepository _eventoRepository;
         public EventosController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        [HttpPost]
        public ActionResult<EventoDomain> Post(EventoDomain evento)
        {
            try
            {
                _eventoRepository.Adicionar(evento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            try
            {
                return _eventoRepository.Listar();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EventoDomain> Get(string id)
        {
            try
            {
                return _eventoRepository.BuscarPorId(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _eventoRepository.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

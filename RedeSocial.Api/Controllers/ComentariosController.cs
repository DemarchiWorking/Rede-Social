using Blls;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.Api.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class ComentariosController : Controller
    {
        public BancoDeDados BancoDeDados { get; }
        
        public ComentariosController(BancoDeDados bancoDeDados)
        {
            BancoDeDados = bancoDeDados;
        }

        [HttpGet]           //resposta pós barra na Query (www...?=id)
        public ActionResult Get([FromQuery] string id)
        {// se nao tiver parametro na query retorne
            if (string.IsNullOrWhiteSpace(id))
            {
                return Ok(BancoDeDados.Comentarios.ToList());
            }
            return Ok(BancoDeDados.Comentarios.Where(x => x.Id.ToString() == id).ToList());
        }
        [HttpPost]
        public ActionResult Post(Comentario parametro)
        {
            var criarComentario = new Comentario();
            criarComentario.Id = Guid.NewGuid();
            criarComentario.TextoComentario = parametro.TextoComentario;
            criarComentario.Data = parametro.Data;

            BancoDeDados.Comentarios.Add(criarComentario);
            BancoDeDados.SaveChanges();

            return Created("api/livros", criarComentario);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var deletar = BancoDeDados.Comentarios.Find(id);

            BancoDeDados.Comentarios.Remove(deletar);
            BancoDeDados.SaveChanges();

            return NoContent();
        }
      
    }


}

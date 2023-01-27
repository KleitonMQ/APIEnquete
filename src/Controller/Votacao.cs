using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEnquete.src.Entities;

namespace apiEnquete.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class Votacao : ControllerBase
    {
        [HttpPut]
        public ActionResult<IEnumerable<PossibilidadeVoto>> Votar(string nomeEnquete, int id)
        {

            Urna lendoUrna = Urna.DesserializarXml<Urna>(nomeEnquete);
            if (lendoUrna == null)
                return BadRequest("Enquete não encontrada.");

            if (lendoUrna.OpcoesEnquete.Any(x => x.ID == id))
            {
                lendoUrna.AdicionarVoto(id);
                lendoUrna.SerializarXml(lendoUrna);
                return Ok(lendoUrna.OpcoesEnquete);
            }
            else
                return BadRequest("Opção de voto inválido.");
        }
    }
}
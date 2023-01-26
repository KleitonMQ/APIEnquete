using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEnquete.src.Entities;

namespace APIEnquete.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class Contagem : ControllerBase
    {
        int valorAtual = 0;

        [HttpGet]
        public ActionResult<IEnumerable<object>> OpcoesDeVoto(string nomeEnquete)
        {
            var urna = Urna.DesserializarXml<Urna>(nomeEnquete);
            if (urna == null)
            {
                return BadRequest("Enquete não encontrada.");
            }

            return Ok(Urna.DesserializarXml<Urna>(nomeEnquete).OpcoesEnquete);
        }


    }
}
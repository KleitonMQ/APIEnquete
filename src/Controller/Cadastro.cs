using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEnquete.src.Entities;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
namespace apiEnquete.src.Controller
{
    
    [ApiController]
    [Route("api/[controller]")]
    
    public class Cadastro : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarEnquete(string nomeEnquete, string[] opcoes)
        {
            if (nomeEnquete == null)
            {
                return BadRequest("Informar o título da enquete.");
            }
            if (opcoes == null || opcoes.Length == 1)
            {
                return BadRequest("Informar pelo menos duas opções para voto.");
            }

            Urna urna = new Urna(nomeEnquete, opcoes);
            urna.SerializarXml(urna);
            return Ok(urna);
        }
    }
}
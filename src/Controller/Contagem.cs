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
        public IEnumerable<PossibilidadeVoto> OpcoesDeVoto(string nomeEnquete)
        {
            // Urna urna = new Urna();
            return Urna.DesserializarXml<Urna>(nomeEnquete).OpcoesEnquete;
        }
        
    }
}
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
        public IEnumerable<PossibilidadeVoto> Votar(string nomeEnquete, int id)
        {

            Urna lendoUrna = Urna.DesserializarXml<Urna>(nomeEnquete);
            lendoUrna.AdicionarVoto(id);
            lendoUrna.SerializarXml(lendoUrna);
            return lendoUrna.OpcoesEnquete;
        }
    }
}
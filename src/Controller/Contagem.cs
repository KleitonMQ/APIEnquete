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
        Urna urna;
        [HttpPost]
        public void Votar(string[] opcoes)
        {
            urna = new Urna(opcoes);
        }
        [HttpGet]
        public List<string> Opcoes()
        {
            return urna.opcoesValidas(); 
        }
    }
}
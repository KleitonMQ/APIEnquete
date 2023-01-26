using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apiEnquete.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuscarEnquetes : ControllerBase
    {
        [HttpGet]
        public ActionResult<string[]> ListarEnquetes()
        {
            
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Enquetes")))
            {
                string[] arquivos = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Enquetes"));
                if (arquivos.Length == 0)
                    return BadRequest("nenhuma enquete encontrada.");

                return Ok(arquivos);
            }

            return BadRequest("nenhuma enquete encontrada.");

            
        }
    }
}
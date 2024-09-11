using ApiClase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        //actua como un singleton 
        private static readonly List<Moneda> LstMonedas = new List<Moneda>();



        [HttpGet]

        public IActionResult Get() 
        {
            if (LstMonedas.Count == 0)
            {
                return NotFound();
            }   
            return Ok(LstMonedas);
        }

        [HttpGet("name")]

        public IActionResult Get(string name) 
        {
            var moneda = LstMonedas.Find(moneda => moneda.Nombre == name);

            if (moneda == null)
            {
                return NotFound("No se encontraron resultados");
            }
            return Ok(moneda);
        }

        [HttpPost]

        public IActionResult postMoneda([FromBody]Moneda moneda)
        {
            try
            {
                if (moneda != null)
                {
                    LstMonedas.Add(moneda);
                    return Ok();
                }else 
                { 
                    return BadRequest(); 
                }
            }
            catch (Exception)
            {
                //internal server 
                return StatusCode(404);
            }
        }


    }
}

using CineBack.Data.Models;
using CineBack.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {

        private readonly IPeliculaService _Service;

        public PeliculaController(IPeliculaService service)
        {
            _Service = service;
        }

        [HttpGet("Fechas/{fecha1}/{fecha2}")]
        public async Task<IActionResult> Get(int fecha1, int fecha2)
        {
            return Ok(await _Service.GetAllFechas(fecha1,fecha2));
        }

        // GET: api/<PeliculaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.GetAll());
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PeliculaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pelicula pelicula)
        {
            try
            {
                pelicula.Estreno = true;
                await _Service.Save(pelicula);
                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            var devuelto = await _Service.GetById(id);

            devuelto.Estreno = false;
            await _Service.Update(devuelto);
        }

        // DELETE api/<PeliculaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

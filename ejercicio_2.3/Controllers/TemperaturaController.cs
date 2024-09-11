using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ejercicio_2._3.Models;

namespace ejercicio_2._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {

        [HttpGet]

        public IActionResult Get() 
        {
            return Ok(RegistroTemp.GetIntance().GetLista());
        }


        [HttpGet("identificacionIOT")]

        public IActionResult GetByIOT(int id) 
        {

            var devuelto = RegistroTemp.GetIntance().GetByID(id);
            
            return Ok(devuelto);
       
        }


    //    var moneda = LstMonedas.Find(moneda => moneda.Nombre == name);

    //        if (moneda == null)
    //        {
    //            return NotFound("No se encontraron resultados");
    //}
    //        return Ok(moneda);














}
}

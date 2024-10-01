using ApiTurno.Models;
using ApiTurno.Repository;
using ApiTurno.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTurno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {

        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpGet]

        public ActionResult GetAll()
        {
            return Ok(_turnoService.GetAll());
        }

        [HttpPost]

        public ActionResult Post([FromBody] TTurno turno) 
        {
            return Ok(_turnoService.Save(turno));
        
        }

        [HttpPut]
        public ActionResult Update([FromBody] TTurno turno, [FromQuery] int id)
        {
            return Ok(_turnoService.Update(turno, id));

        }




    }
}

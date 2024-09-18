using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorioTurno.Entities;
using RepositorioTurno.Services;

namespace ApiTurno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {

        private readonly ITurnoService _turnoService;

        public TurnoController()
        {
            _turnoService = new TurnoService();
        }


        [HttpGet] 

        public IActionResult GetServicios() 
        {
            try
            {
                return Ok(_turnoService.GetAllSevices());
            }
            catch (Exception)
            {
                throw new Exception();
                //return NoContent();
            }
        }


        [HttpPost] 

        public IActionResult PostTurno([FromBody] Turno turno) 
        {
            return Ok(_turnoService.InsertarMestroDetalle(turno));
        
        
        }



    }
}

<<<<<<< HEAD
﻿using ApiTurno.Models;
using ApiTurno.Repository;
using ApiTurno.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorioTurno.Entities;
using RepositorioTurno.Services;
>>>>>>> 506acc96fd2103906ea70dc95b04c7db12b4712b

namespace ApiTurno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {

        private readonly ITurnoService _turnoService;

<<<<<<< HEAD
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


=======
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

>>>>>>> 506acc96fd2103906ea70dc95b04c7db12b4712b


    }
}

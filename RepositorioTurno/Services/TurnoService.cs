using RepositorioTurno.Entities;
using RepositorioTurno.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Services
{

    public interface ITurnoService
    {
        int ContarTurnos();

        bool InsertarMestroDetalle(Turno turno);

        List<Servicio> GetAllSevices();

    }

    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepositorycs _service;

        public TurnoService()
        {
            _service = new TurnoRepository();
        }

        public int ContarTurnos()
        {
            throw new NotImplementedException();
        }

        public List<Servicio> GetAllSevices()
        {
            return _service.GetAllServices();
        }

        public bool InsertarMestroDetalle(Turno turno)
        {
            return _service.InsertarMestroDetalle(turno);
        }
    }
}

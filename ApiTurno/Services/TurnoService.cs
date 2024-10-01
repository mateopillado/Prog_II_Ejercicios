using ApiTurno.Models;

namespace ApiTurno.Services
{

    public interface ITurnoService
    {
        List<TTurno> GetAll();
        bool Save(TTurno turno);

        bool Update(TTurno turno, int id);

        bool Delete(int id);
    }

    public class TurnoService : ITurnoService
    {

        private readonly ITurnoService _service;

        public TurnoService(ITurnoService turnoRepository)
        {
            _service = turnoRepository; //de esta forma es inyeccion de dependencias
        }



        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<TTurno> GetAll()
        {
            return _service.GetAll();
        }

        public bool Save(TTurno turno)
        {
            return _service.Save(turno);
        }

        public bool Update(TTurno turno, int id)
        {
            //intentar haacer un update con el metodo atach 
            return _service.Update(turno,id);
        }
    }
}

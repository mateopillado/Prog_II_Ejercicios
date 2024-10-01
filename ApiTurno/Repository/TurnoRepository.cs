using ApiTurno.Models;

namespace ApiTurno.Repository
{

    public interface ITurnoRepository
    {
        List<TTurno> GetAll();
        bool Save(TTurno turno);

        bool Update(TTurno turno);

        bool Delete (int id);
    }

    public class TurnoRepository : ITurnoRepository
    {

        //inyeccion
        private readonly turnos_dbContext _DbContext;

        public TurnoRepository(turnos_dbContext context)
        {
            _DbContext = context;
        }
        //hasta aca
        public bool Delete(int id)
        {
            var turnos = _DbContext.TTurnos.Find(id);
            _DbContext.TTurnos.Remove(turnos);
            return _DbContext.SaveChanges() > 0;
        }

        public List<TTurno> GetAll()
        {
            return _DbContext.TTurnos.ToList();
            //si queremos filtrar
            //return _DbContext.TTurnos.Where(x => x.Hora == "8:20").ToList();
        }

        public bool Save(TTurno turno)
        {

            _DbContext.TTurnos.Add(turno);

            return _DbContext.SaveChanges() > 0;

        }

        public bool Update(TTurno turno, int id)
        {
            _DbContext.TTurnos.Update(turno);

            return _DbContext.SaveChanges() > 0;
        }
    }
}

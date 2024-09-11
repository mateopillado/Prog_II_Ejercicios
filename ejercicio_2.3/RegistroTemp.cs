using ejercicio_2._3.Models;

namespace ejercicio_2._3
{
    public class RegistroTemp
    {

        private List<Temperatura> lstTemps;
        private static RegistroTemp _instance;

        private RegistroTemp()
        {
            lstTemps = new List<Temperatura>();
        }


        public static RegistroTemp GetIntance()
        {
            if (_instance == null)
            {
                _instance = new RegistroTemp();
            }
            return _instance;
        }

        public List<Temperatura> GetLista() 
        {
            return lstTemps;
        }

        public List<Temperatura> GetByID(int id)
        {
            return lstTemps.Where(Temperatura => Temperatura.idIOT == id).ToList();
        }
       

    }
}

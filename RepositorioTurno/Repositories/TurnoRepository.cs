using Banco.Utils;
using RepositorioTurno.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Repositories
{

    public interface ITurnoRepositorycs
    {
        List<Servicio> GetAllServices();

        int ContarTurnos(string fecha, string hora);

        bool InsertarMestroDetalle(Turno turno);


    }
    public class TurnoRepository : ITurnoRepositorycs
    {
        public int ContarTurnos(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public List<Servicio> GetAllServices()
        {
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_MOSTRAR_SERVICIOS",null);

            var lst = new List<Servicio>();


            foreach (DataRow item in dt.Rows)
            {
                var oService = new Servicio
                {
                    Id = (int)item["id"],
                    Nombre = item["nombre"].ToString(),
                    Costo = (int)item["costo"],
                    EnPromocion = item["enPromocion"].ToString()
                };

                lst.Add(oService);

            }

            return lst;

        }

        public bool InsertarMestroDetalle(Turno turno)
        {
            bool result = true;
            SqlConnection conection = null;
            SqlTransaction ts = null;

            try
            {
                conection = DataHelper.GetInstance().GetConeccion();
                conection.Open();    
                ts = conection.BeginTransaction();

                var cmdMaestro = new SqlCommand("Sp_Insertar_maestro", conection,ts);

                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.AddWithValue("fecha", turno.Fecha);
                cmdMaestro.Parameters.AddWithValue("hora", turno.Hora);
                cmdMaestro.Parameters.AddWithValue("cliente", turno.cliente);

                //creacion del parametro de salida 
                var paramSalida = new SqlParameter("id", SqlDbType.Int);
                paramSalida.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(paramSalida);

                cmdMaestro.ExecuteNonQuery();

                int turnoId = (int) paramSalida.Value;

                foreach (var item in turno.lstDetalles)
                {
                    var cmdDetalle = new SqlCommand("sp_insert_detalle",conection,ts);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("id_turno",turnoId);
                    cmdDetalle.Parameters.AddWithValue("id_servicio", item.ServicioId);
                    cmdDetalle.Parameters.AddWithValue("observaciones", item.Observaciones);

                    cmdDetalle.ExecuteNonQuery();
                }
                ts.Commit();
            }
            catch (Exception)
            {
                result = false;
                ts.Rollback();
            }
            finally
            {
                conection.Close();
            }

            return result;
        }
    }
}

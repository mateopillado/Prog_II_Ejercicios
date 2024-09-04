using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    internal class BudgetRepository : IBudgetRepository
    {
        public List<Budget> GetAll()
        {
            throw new NotImplementedException();
        }

        public Budget GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Budget budget)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction transaction = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                transaction = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_MASTRO", cnn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", budget.Client);
                cmd.Parameters.AddWithValue("@vigencia", budget.Expiration);

                //parametro de salida 
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int budgetID = (int)param.Value;
                int detailId = 1;
                foreach (var detail in budget.Details)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, transaction);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@detalle", detailId);
                    cmdDetail.Parameters.AddWithValue("@presupuesto", budgetID);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Cant);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);
                    cmdDetail.ExecuteNonQuery();
                    detailId += 1;
                }




                transaction.Commit();
            }
            catch (SqlException)
            {
                if (transaction != null)
                    transaction.Rollback();
                result = false;
            }
            finally 
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }




            




            return result;
        }
    }
}

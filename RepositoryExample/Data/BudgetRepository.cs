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

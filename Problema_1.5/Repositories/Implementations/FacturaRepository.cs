using Problema_1._5.Domain;
using Problema_1._5.Repositories.Contracs;
using Problema_1._5.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Repositories.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        public bool Add(Factura fact)
        {
            SqlTransaction transaction = null;
            SqlConnection cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();

                transaction = cnn.BeginTransaction();

                var cmd = new SqlCommand("sp_Insert_Factura", cnn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", fact.Cliente);
                cmd.Parameters.AddWithValue("@idFormaPago", fact.FormaPago.Id);
                cmd.Parameters.AddWithValue("@activo", 0);

                var param = new SqlParameter("nroFactura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int nroFactura = (int) param.Value;

                foreach (var item in fact.DetalleList)
                {
                    var cmdDetalle = new SqlCommand("sp_Insert_Detalles", cnn,transaction);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@nroFactura", nroFactura);
                    cmdDetalle.Parameters.AddWithValue("@articulo", item.Articulo_.Id);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@pre_venta", item.Precio);

                    cmdDetalle.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (SqlException)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                cnn.Close();   
            }

            return true;
        }

        public bool Delete(int nroFactura)
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            var facturaList = new List<Factura>();

            var dt = DataHelper.GetInstance().ExecuteSPQuery("sp_Consult_Facturas", null);
            
            foreach (DataRow factura in dt.Rows)
            {
                var oForma = new FormaPago
                {
                    Id = (int)factura["idForma"],
                    Nombre = (string)factura["formaPago"]
                };

                var oFactura = new Factura
                {
                    Id = (int)factura["nro_factura"],
                    Fecha = (DateTime)factura["fecha"],
                    Cliente = (int)factura["cliente"],
                    FormaPago = oForma
                };
                facturaList.Add(oFactura);
            }

            return facturaList;
        }

        public List<DetalleFactura> GetById(int nroFactura)
        {
            var lst = new List<DetalleFactura>();

            var param = new List<Parameter>
            {
                new Parameter("@nro_factura", nroFactura)
            };

            var dt = DataHelper.GetInstance().ExecuteSPQuery("sp_consult_facturasById", param);

            foreach (DataRow item in dt.Rows)
            {
                var detalle = new DetalleFactura
                {
                    IdFactura = (int)item["nro_factura"],
                    Cantidad = (int)item["cantidad"],
                    Precio = (decimal)item["pre_venta"],
                    Articulo_ = new Articulo
                    {
                        Nombre = item["nombre"].ToString(),
                        Id = (int)item["cod_art"]
                    }
                };
               
                lst.Add(detalle);

            }

            return lst;
        }
    }
}

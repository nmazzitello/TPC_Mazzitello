using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlDataReader lector { get; set; }

        public SqlConnection conexion { get; set; }

        public SqlCommand comando { get; set; }

        public AccesoDatos()
        {
            conexion = new SqlConnection("data source= DESKTOP-NBAJLFJ\\SQLEXPRESS; initial catalog= tpc_Mazzitello_mfPrestamos; integrated security= sspi");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        //metodo para realizar la consulta
        public void setearQuery(String consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearView(string view)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = view;
        }

        public void agregarParametro(String nombre, Object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void ejecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

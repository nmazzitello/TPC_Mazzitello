using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProvincia
    {
        //METODO QUE CARGA UNA LISTA CON TODAS LAS PROVINCIAS DE LA DB --> 100%
        public List<Provincia> cargarProvincias()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Provincia> listado = new List<Provincia>();

                datos.setearQuery("select idProvincia, provincia from provincia");
                datos.ejecutarLector();


                while (datos.lector.Read())
                {
                    Provincia pr = new Provincia();
                    pr.idProvincia = (int)datos.lector.GetInt64(0);
                    pr.provincia = datos.lector.GetString(1);

                    listado.Add(pr);
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO QUE TRAE UNA PROVINCIA ESPECIFICA --> 
        public Provincia traerProv(long idProv)
        {
            AccesoDatos datos = new AccesoDatos();
            Provincia pr = new Provincia();

            try
            {
                datos.setearQuery("select idProvincia, Provincia from provincia where idProvincia=" + idProv);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {

                    pr.idProvincia = datos.lector.GetInt64(0);
                    pr.provincia = datos.lector.GetString(1);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return pr;
        }
    }
}

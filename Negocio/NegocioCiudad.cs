using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioCiudad
    {
        //METODO QUE TRAE TODAS LAS CIUDADES EN UNA LISTA--> 100%
        public List<Ciudad> cargarCiudades()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Ciudad> listado = new List<Ciudad>();

                datos.setearQuery("select idCiudad, ciudad from ciudad");
                datos.ejecutarLector();


                while (datos.lector.Read())
                {
                    Ciudad cd = new Ciudad();
                    cd.idCiudad = (int)datos.lector.GetInt64(0);
                    cd.ciudad = datos.lector.GetString(1);

                    listado.Add(cd);
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

        //METODO QUE TRAE UNA CIUDAD ESPECIFICA --> 100%
        public Ciudad traerCiu(long idCiu)
        {
            AccesoDatos datos = new AccesoDatos();
            Ciudad ci = new Ciudad();

            try
            {
                datos.setearQuery("select idCiudad, ciudad from ciudad where idCiudad=" + idCiu);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {

                    ci.idCiudad = datos.lector.GetInt64(0);
                    ci.ciudad = datos.lector.GetString(1);
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
            return ci;
        }
    }
}

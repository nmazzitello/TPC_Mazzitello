using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioNacionalidad
    {
        //METODO QUE CARGA TODOS LOS PAISES EN UNA LISTA --> 100%
        public List<Nacionalidad> cargarNacionalidades()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Nacionalidad> listado = new List<Nacionalidad>();

                datos.setearQuery("select idNacionalidad, nacionalidad from nacionalidad");
                datos.ejecutarLector();


                while (datos.lector.Read())
                {
                    Nacionalidad na = new Nacionalidad();
                    na.idNacionalidad = datos.lector.GetInt32(0);
                    na.nacionalidad = datos.lector.GetString(1);

                    listado.Add(na);
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

        //METODO QUE TRAE UNA NACIONALIDAD ESPECIFICA --> 100%
        public Nacionalidad traerNac(int idNac)
        {
            AccesoDatos datos = new AccesoDatos();
            Nacionalidad na = new Nacionalidad();

            try
            {
                datos.setearQuery("select idNacionalidad, nacionalidad from nacionalidad where idNacionalidad="+idNac);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    
                    na.idNacionalidad = datos.lector.GetInt32(0);
                    na.nacionalidad = datos.lector.GetString(1);
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
            return na;
        }
    }
}

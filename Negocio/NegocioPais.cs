using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPais
    {
        //METODO QUE TRAE TODOS LOS PAISES PARA CARGAR EL DDL --> 100%
        public List<Pais> cargarPaises()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Pais> listado = new List<Pais>();

                datos.setearQuery("select idPais, pais from pais");
                datos.ejecutarLector ();
                

                while (datos.lector.Read())
                {
                    Pais pa= new Pais();
                    pa.idPais = datos.lector.GetInt32(0);
                    pa.pais = datos.lector.GetString(1);

                    listado.Add(pa);
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

        //METODO QUE TRAE UNA PAIS ESPECIFICA -->  100%
        public Pais traerPais(int idPais)
        {
            AccesoDatos datos = new AccesoDatos();
            Pais pa = new Pais();

            try
            {
                datos.setearQuery("select idPais, pais from pais where idPais=" + idPais);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {

                    pa.idPais = datos.lector.GetInt32(0);
                    pa.pais = datos.lector.GetString(1);
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
            return pa;
        }

    }
}

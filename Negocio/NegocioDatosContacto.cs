using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioDatosContacto
    {
        //METODO QUE GUARDA LOS DATOS PARA CONTACTAR AL CLIENTE --> 100%
        public DatosContacto cargarDatosCOntacto(long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();
            DatosContacto dc = new DatosContacto();

            try
            {
                datos.setearQuery("select cl.telefonoPrin, cl.telefonoAux, cl.mail from cliente as cl where cl.idCliente ="+idUsu);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    dc.telefonoPrinc = datos.lector.GetString(0);
                    dc.telefonoAux = datos.lector.GetString(1);
                    dc.mail = datos.lector.GetString(2);
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
            return dc;
        }

    }
}

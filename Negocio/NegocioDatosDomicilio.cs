using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioDatosDomicilio
    {
        //METODO QUE CARGA UN OBJETO DATOSDOMICILIO --> 100%
        public DatosDomicilio cargarDatosDomicilio(long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();
            DatosDomicilio dd = new DatosDomicilio();

            try
            {
                datos.setearQuery("select cl.domicilio, c.idCiudad, c.ciudad, p.idProvincia, p.provincia, pa.idPais, pa.pais from cliente as cl inner join ciudad as c on c.idCiudad = cl.idCiudad inner join provincia as p on p.idProvincia = c.idProvincia inner join pais as pa on pa.idPais = p.idPais where cl.idCliente = " + idUsu);
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    dd.direccion = datos.lector.GetString(0);

                    Ciudad ciu = new Ciudad();
                    ciu.idCiudad= datos.lector.GetInt64(1);
                    ciu.ciudad= datos.lector.GetString(2);
                    dd.ciudad = ciu;

                    Provincia pro = new Provincia();
                    pro.idProvincia= datos.lector.GetInt64(3);
                    pro.provincia= datos.lector.GetString(4);
                    dd.provincia = pro;

                    Pais pai = new Pais();
                    pai.idPais = datos.lector.GetInt32(5);
                    pai.pais = datos.lector.GetString(6);
                    dd.pais = pai;
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
            return dd;
        }
    }
}

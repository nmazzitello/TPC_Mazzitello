using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioDatosLaborales
    {
        //METODO QUE CARGA LOS DATOS LABORALES DEL CLIENTE --> 100%
        public DatosLaborales traerDatosLaborales(long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();
            DatosLaborales dl = new DatosLaborales();

            try
            {
                datos.setearQuery("select cl.trabaja, cl.rubro, cl.sueldo, cl.ingresoExtra, cl.razonIngExt, cl.montoIngExt from cliente as cl where cl.idCliente =" + idUsu);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    dl.trabaja = datos.lector.GetBoolean(0);
                    if(datos.lector.IsDBNull(1)==true)
                    {
                        dl.rubro = "Pendiente";
                    }
                    else
                    {
                        dl.rubro = datos.lector.GetString(1);
                    }
                    dl.sueldo =  datos.lector.GetSqlMoney(2).ToString();
                    dl.ingresoExtra = datos.lector.GetBoolean(3);
                    if(datos.lector.IsDBNull(4)==true)
                    {
                        dl.razonIngresoExtra = "Pendiente";
                    }
                    else
                    {
                        dl.razonIngresoExtra = datos.lector.GetString(4);
                    }
                    dl.montoIngExt = datos.lector.GetSqlMoney(5).ToString();
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
            return dl;
        }
    }
}

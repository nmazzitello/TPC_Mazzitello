using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioGastosAdm
    {
        //METODO QUE CARGA UNA LISTA CON TODOS LAS OPCIONES DE GASTOS ADMINISTRATIVOS POSIBLES -->  100%
        public List<GastosAdministrativos> traerGastosAdm ()
        {
            AccesoDatos datos = new AccesoDatos();
            List<GastosAdministrativos> listado = new List<GastosAdministrativos>();

            try
            {
                datos.setearQuery("select * from gastosAdm");
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    GastosAdministrativos ga = new GastosAdministrativos();

                    ga.idGastosAdm = datos.lector.GetInt32(0);
                    ga.monto = datos.lector.GetSqlMoney(1).ToString();
                    ga.meses = datos.lector.GetInt32(2);
                    ga.detalles = datos.lector.GetString(3);

                    listado.Add(ga);
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

        //METODO QUE CARGA UN OBJETO DE GASTOS ADMINISTRATIVO -- %
        public GastosAdministrativos cargarGastoAdm(int idGasAdm)
        {
            AccesoDatos datos = new AccesoDatos();
            GastosAdministrativos ga = new GastosAdministrativos();

            try
            {
                datos.setearQuery("select * from gastosAdm where idGastosAdm="+ idGasAdm);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    ga.idGastosAdm = datos.lector.GetInt32(0);
                    ga.monto = datos.lector.GetSqlMoney(1).ToString();
                    ga.meses = datos.lector.GetInt32(2);
                    ga.detalles = datos.lector.GetString(3);
                }
                return ga;
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

        //METODO QUE GUARDA EL OBJETO GASTO ADMINISTRATIVO MODIFICADO --
        public void modificarGastoAdm(GastosAdministrativos gad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_modificar_gasto_adm");

                datos.agregarParametro("@idGastosAdm", gad.idGastosAdm);
                datos.agregarParametro("@monto", gad.monto);
                datos.agregarParametro("@meses", gad.meses);
                datos.agregarParametro("@detalles", gad.detalles);

                datos.ejecutarAccion();
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

        //METODO PARA AGREGAR UN NUEVO GASTO ADMINISTRATIVO --> 
        public Boolean agregarGastoAdm(GastosAdministrativos gadm)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_agregar_gasto_adm");

                datos.agregarParametro("@monto", gadm.monto);
                datos.agregarParametro("@meses", gadm.meses);
                datos.agregarParametro("@detalles", gadm.detalles);

                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                return false;   
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

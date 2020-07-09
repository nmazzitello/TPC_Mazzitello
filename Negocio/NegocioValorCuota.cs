using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioValorCuota
    {

        //METODO QUE GUARDA EL OBJETO VALOR DE LAS CUOTAS EN LA DB --> 100%
        public void guardarValorCuota(List<ValorCuota> lval, long idPres, int cantCuo)
        {
            try
            {
                for (int x = 0; x < cantCuo; x++)
                {
                    AccesoDatos datos = new AccesoDatos();

                    DateTime hoy = DateTime.Now;
                    DateTime atrasada = hoy.AddMonths(x + 1);
                    DateTime vencida = atrasada.AddDays(10);

                    datos.setearSP("sp_guardar_valor_cuota");

                    datos.agregarParametro("@numeroCuota", x + 1);
                    datos.agregarParametro("@idPrestamo", idPres);
                    datos.agregarParametro("@valorCuota", lval[x].valorCuota);
                    datos.agregarParametro("@valorCuotaAtrasada", lval[x].valorCuotaAtrasada);
                    datos.agregarParametro("@valorCuotaVencida", lval[x].valorCuotaVencida);
                    datos.agregarParametro("@cuotaEstaAtrasada", atrasada.ToString("yyyy-MM-dd HH:mm:ss"));
                    datos.agregarParametro("@cuotaEstaVencida", vencida.ToString("yyyy-MM-dd HH:mm:ss"));

                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO QUE GUARDA LA FECHA DE PAGO DE LA CUOTA Y EL COMPROBANTE --> 100%
        public bool confirmarPagoCuota(int numCuo, long idPre, String comprob)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_confirmar_pago_cuota");

                datos.agregarParametro("@numeroCuota", numCuo);
                datos.agregarParametro("@idPrestamo", idPre);
                datos.agregarParametro("@comprobantePago", comprob);

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

        //METODO QUE TRAE EL UTIMO VALOR DE CUOTA --> 100%
        public List<ValorCuota> traerValorCuotas(long idPre, int cantCuo)
        {
            List<ValorCuota> listadoValor = new List<ValorCuota>();
            
            try
            {
                for(int x=0; x<cantCuo; x++)
                {
                    AccesoDatos datos = new AccesoDatos();
                    int numCuo = x + 1;

                    datos.setearQuery("select * from valorCuota where idPrestamo ="+ idPre +" and numeroCuota ="+ numCuo +" order by idPrestamo desc");
                    datos.ejecutarLector();

                    if(datos.lector.Read())
                    {
                        ValorCuota val = new ValorCuota();

                        val.numeroCuota = datos.lector.GetInt32(0);
                        val.valorCuota = float.Parse(datos.lector.GetSqlMoney(2).ToString());
                        val.valorCuotaAtrasada = float.Parse(datos.lector.GetSqlMoney(3).ToString());
                        val.valorCuotaVencida = float.Parse(datos.lector.GetSqlMoney(4).ToString());
                        val.fechaAtrasada = datos.lector.GetDateTime(5);
                        val.fechaAtrasadaLinda = val.fechaAtrasada.ToShortDateString();
                        val.fechaVencida = datos.lector.GetDateTime(6);
                        val.fechaVencidaLinda = val.fechaVencida.ToShortDateString();
                        if(datos.lector.IsDBNull(7)==false)
                        {
                            val.fechaPagoCliente = datos.lector.GetDateTime(7);
                            val.fechaPagoClienteLinda = val.fechaPagoCliente.ToShortDateString();
                        }
                        else
                        {
                            val.fechaPagoClienteLinda = "Pendiente";
                        }
                        listadoValor.Add(val);
                    }
                }
                return listadoValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
    


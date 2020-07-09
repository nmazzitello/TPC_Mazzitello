using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPrestamo
    {
        //METODO QUE GENERA UN NUEVO PRESTAMO --> 100%
        public bool generarPrestamo(Prestamo pres)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_crear_prestamo");

                datos.agregarParametro("@monto", pres.monto);
                datos.agregarParametro("@cuotas", pres.cantCuotas);
                datos.agregarParametro("@idGastosAdm", pres.gastosAdm.idGastosAdm);
                datos.agregarParametro("@idProducto", pres.prodGarantia.idProducto);

                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //METODO QUE OBTIENE EL ID DEL PRESTAMO RECIEN CREADO --> 100%
        public long obtenerIdDelPrestamo()
        {
            AccesoDatos datos = new AccesoDatos();
            long idPres;

            try
            {
                datos.setearQuery("select top 1 idPrestamo from prestamo order by idPrestamo desc");
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    idPres = datos.lector.GetInt64(0);
                    return idPres;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        //METODO QUE CARGA UNA LISTA CON TODOS LOS PRESTAMOS --> 100%
        public List<Prestamo> listarPrestamos()
        {
            List<Prestamo> listado = new List<Prestamo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select p.idPrestamo, p.estado, p.fecha, p.monto, p.cuotas, p.idGastosAdm, p.idProducto, c.idCliente from prestamo as p inner join producto as pr on pr.idProducto = p.idProducto inner join cliente as c on c.idCliente = pr.idCliente");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Prestamo pres = new Prestamo();

                    pres.idPrestamo = datos.lector.GetInt64(0);

                    pres.estado = datos.lector.GetBoolean(1);
                    if(pres.estado==true)
                    {
                        pres.estadoLindo = "Activo";
                    }
                    else
                    {
                        pres.estadoLindo = "Finalizado";
                    }

                    pres.fecha = datos.lector.GetDateTime(2);
                    pres.monto = datos.lector.GetSqlMoney(3).ToInt32();
                    pres.cantCuotas = datos.lector.GetInt32(4);

                    GastosAdministrativos gad = new GastosAdministrativos();
                    NegocioGastosAdm ng = new NegocioGastosAdm();
                    gad = ng.cargarGastoAdm(datos.lector.GetInt32(5));
                    pres.gastosAdm = gad;

                    //ValorCuota val = new ValorCuota();
                    //NegocioValorCuota nv = new NegocioValorCuota();
                    //val = nv.escojerCuota(datos.lector.GetInt64(6));
                    //pres.valorCuota = val;

                    Producto pro = new Producto();
                    NegocioProducto np = new NegocioProducto();
                    pro = np.cargarProducto(datos.lector.GetInt64(6));
                    pres.prodGarantia = pro;

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(7));
                    pres.cliente = cli;

                    listado.Add(pres);
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

        //METODO QUE CARGA UNA LISTA CON TODOS LOS PRESTAMOS DE UN CLIENTE--> 100%
        public List<Prestamo> listarPrestamosDeCliente(long idCli)
        {
            List<Prestamo> listado = new List<Prestamo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select p.idPrestamo, p.estado, p.fecha, p.monto, p.cuotas, p.idGastosAdm, p.idProducto, c.idCliente from prestamo as p inner join producto as pr on pr.idProducto = p.idProducto inner join cliente as c on c.idCliente = pr.idCliente where c.idCliente=" + idCli);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Prestamo pres = new Prestamo();

                    pres.idPrestamo = datos.lector.GetInt64(0);

                    pres.estado = datos.lector.GetBoolean(1);
                    if (pres.estado == true)
                    {
                        pres.estadoLindo = "Activo";
                    }
                    else
                    {
                        pres.estadoLindo = "Finalizado";
                    }

                    pres.fecha = datos.lector.GetDateTime(2);
                    pres.monto = datos.lector.GetSqlMoney(3).ToInt32();
                    pres.cantCuotas = datos.lector.GetInt32(4);

                    GastosAdministrativos gad = new GastosAdministrativos();
                    NegocioGastosAdm ng = new NegocioGastosAdm();
                    gad = ng.cargarGastoAdm(datos.lector.GetInt32(5));
                    pres.gastosAdm = gad;

                    Producto pro = new Producto();
                    NegocioProducto np = new NegocioProducto();
                    pro = np.cargarProducto(datos.lector.GetInt64(6));
                    pres.prodGarantia = pro;

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(7));
                    pres.cliente = cli;

                    listado.Add(pres);
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

        //METODO QUE CARGA UN OBJETO PRESTAMO --> 100%
        public Prestamo cargarPrestamo(long idPre)
        {
            Prestamo pre = new Prestamo();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select * from prestamo where idPrestamo= " + idPre);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    pre.idPrestamo = datos.lector.GetInt64(0);
                    pre.estado = datos.lector.GetBoolean(1);
                    pre.fecha = datos.lector.GetDateTime(2);
                    pre.monto = datos.lector.GetSqlMoney(3).ToInt32();
                    pre.cantCuotas = datos.lector.GetInt32(4);

                    GastosAdministrativos gad = new GastosAdministrativos();
                    NegocioGastosAdm ng = new NegocioGastosAdm();
                    gad = ng.cargarGastoAdm(datos.lector.GetInt32(5));
                    pre.gastosAdm = gad;

                    Producto pro = new Producto();
                    NegocioProducto np = new NegocioProducto();
                    pro = np.cargarProducto(datos.lector.GetInt64(6));
                    pre.prodGarantia = pro;

                    List<ValorCuota> listadoValorCuota = new List<ValorCuota>();
                    NegocioValorCuota nv = new NegocioValorCuota();
                    listadoValorCuota = nv.traerValorCuotas(idPre, pre.cantCuotas);
                    pre.datosCuota = listadoValorCuota;

                    NegocioCliente nc = new NegocioCliente();
                    Cliente cli = new Cliente();
                    cli = nc.cargarClientePorProducto(pro.idProducto);
                    pre.cliente = cli;
                }
                return pre;
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

        //METODO QUE VERIFICA SI TIENE UN PRESTAMO ACTIVO EL CLIENTE AL MOMENTO DE OTORGARLE UNO NUEVO --> 100%
        //si devuelve false, se puede dar prestamo
        public bool verificarSiTieneActivoPrestamo(long idCli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select top 1 p.estado from prestamo as p inner join producto as pr on pr.idProducto = p.idProducto inner join cliente as c on c.idCliente = pr.idCliente where c.idCliente = "+ idCli+" order by p.idPrestamo desc");
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    bool resultado = datos.lector.GetBoolean(0);
                    if(resultado==true)
                    {
                        return true ;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return true; ;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO PARA CONFIRMAR QUE TODAS LAS CUOTAS ESTEN PAGAS Y FINALIZAR EL PRESTAMO --> 100%
        public bool finalizarPrestamo(long idPre, int cantCuo)
        {
            try
            {
                for(int x=0; x< cantCuo;x++)
                {
                    AccesoDatos datos = new AccesoDatos();
                    int cuo = x + 1;
                    datos.setearQuery("select fechaPagoCliente from valorCuota where idPrestamo =" + idPre + " and numerocuota="+ cuo);
                    datos.ejecutarLector();

                    if(datos.lector.Read())
                    {
                        if( datos.lector.IsDBNull(0))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO QUE CAMBIA EL ESTADO DE ACTIVO -1- A FINALIZADO -0- --> 100%
        public void finalizarPrestamo(long idPre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_finalizar_prestamo");
                datos.agregarParametro("@idPrestamo", idPre);
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
    }
}

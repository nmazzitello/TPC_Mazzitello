using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioSolicitud
    {
        //METODO PARA GUARDAR LA SOLICITUD DE PRESTAMO --100 %
        public bool guardarSolicitud(Solicitud sol)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_alta_solicitud");
                datos.agregarParametro("@montoSolicitado",sol.montoSolicitado);
                datos.agregarParametro("@cantidadCuotas",sol.cantidadCuotas);
                datos.agregarParametro("@idProducto", sol.producto.idProducto);

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

        //METODO PARA CARGAR UNA SOLICITUD DE PRESTAMO -- 100%
        public Solicitud cargarSolicitud(long idSol)
        {
            AccesoDatos datos = new AccesoDatos();
            Solicitud sol = new Solicitud();

            try
            {
                datos.setearQuery("select s.idSolicitud, s.fecha, c.idCliente, s.montoSolicitado, s.cantidadCuotas, s.idProducto, s.estado, s.observacion from solicitud as s inner join producto as p on p.idProducto = s.idProducto inner join cliente as c on c.idCliente = p.idCliente where s.idSolicitud ="+idSol);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    sol.idSolicitud = datos.lector.GetInt64(0);
                    sol.fecha = datos.lector.GetDateTime(1);

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(2));
                    sol.cliente = cli;

                    sol.montoSolicitado = datos.lector.GetSqlMoney(3).ToString();
                    sol.cantidadCuotas = datos.lector.GetInt32(4);

                    Producto pro = new Producto();
                    NegocioProducto np = new NegocioProducto();
                    pro = np.cargarProducto(datos.lector.GetInt64(5));
                    sol.producto = pro;

                    sol.estado = datos.lector.GetInt32(6);
                    
                    sol.observacion = datos.lector.GetString(7);

                }
                return sol;
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

        //METODO QUE LISTA TODAS LAS SOLICITUDES --> 100%
        public List<Solicitud> listarSolicitudes()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Solicitud> listado = new List<Solicitud>();

            try
            {
                datos.setearQuery("select s.idSolicitud, s.fecha, s.montoSolicitado, s.cantidadCuotas, p.producto, p.marca, p.modelo, p.detalles, p.estado, p.imagen, cl.idCliente, s.estado, s.observacion from solicitud as s inner join producto as p on p.idProducto = s.idProducto inner join cliente as cl on cl.idCliente = p.idCliente");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Solicitud sol = new Solicitud();

                    sol.idSolicitud = datos.lector.GetInt64(0);
                    sol.fecha= datos.lector.GetDateTime(1);
                    sol.montoSolicitado= datos.lector.GetSqlMoney(2).ToString();
                    sol.cantidadCuotas= datos.lector.GetInt32(3);

                    Producto prod = new Producto();
                    prod.producto = datos.lector.GetString(4);
                    prod.marca = datos.lector.GetString(5);
                    prod.modelo = datos.lector.GetString(6);
                    prod.detalles = datos.lector.GetString(7);
                    prod.estado = datos.lector.GetString(8);
                    prod.imagen = datos.lector.GetString(9);
                    sol.producto = prod;

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(10));
                    sol.cliente = cli;

                    sol.estado= datos.lector.GetInt32(11);
                    sol.observacion = datos.lector.GetString(12);
                    listado.Add(sol);
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

        //METODO QUE LISTA TODAS LAS SOLICITUDES DE UN DETERMINADO CLIENTE --> 100%
        public List<Solicitud> listarSolicitudesDeCliente(long idCli)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Solicitud> listado = new List<Solicitud>();

            try
            {
                datos.setearQuery("select s.idSolicitud, s.fecha, s.montoSolicitado, s.cantidadCuotas, p.producto, p.marca, p.modelo, p.detalles, p.estado, p.imagen, cl.idCliente, s.estado, s.observacion from solicitud as s inner join producto as p on p.idProducto = s.idProducto inner join cliente as cl on cl.idCliente = p.idCliente where cl.idCliente=" + idCli);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Solicitud sol = new Solicitud();

                    sol.idSolicitud = datos.lector.GetInt64(0);
                    sol.fecha = datos.lector.GetDateTime(1);
                    sol.montoSolicitado = datos.lector.GetSqlMoney(2).ToString();
                    sol.cantidadCuotas = datos.lector.GetInt32(3);

                    Producto prod = new Producto();
                    prod.producto = datos.lector.GetString(4);
                    prod.marca = datos.lector.GetString(5);
                    prod.modelo = datos.lector.GetString(6);
                    prod.detalles = datos.lector.GetString(7);
                    prod.estado = datos.lector.GetString(8);
                    prod.imagen = datos.lector.GetString(9);
                    sol.producto = prod;

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(10));
                    sol.cliente = cli;

                    sol.estado = datos.lector.GetInt32(11);
                    if (sol.estado == 0)
                    {
                        sol.estadoLindo = "Rechazado";
                    }
                    else if (sol.estado == 1)
                    {
                        sol.estadoLindo = "Aprobado";
                    }
                    else
                    {
                        sol.estadoLindo = "Pendiente";
                    }

                    sol.observacion =datos.lector.GetString(12);
                    listado.Add(sol);
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

        //METODO QUE LISTA TODAS LAS SOLICITUDES CON UNA VIEW--> 100%
        public List<Solicitud> listarSolicitudesConView()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Solicitud> listado = new List<Solicitud>();

            try
            {
                datos.setearQuery("SELECT * FROM vw_listar_solicitudes");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Solicitud sol = new Solicitud();

                    sol.idSolicitud = datos.lector.GetInt64(0);
                    sol.fecha = datos.lector.GetDateTime(1);
                    sol.montoSolicitado = datos.lector.GetSqlMoney(2).ToString();
                    sol.cantidadCuotas = datos.lector.GetInt32(3);

                    Producto prod = new Producto();
                    prod.producto = datos.lector.GetString(4);
                    prod.marca = datos.lector.GetString(5);
                    prod.modelo = datos.lector.GetString(6);
                    prod.detalles = datos.lector.GetString(7);
                    prod.estado = datos.lector.GetString(8);
                    prod.imagen = datos.lector.GetString(9);
                    sol.producto = prod;

                    Cliente cli = new Cliente();
                    NegocioCliente nc = new NegocioCliente();
                    cli = nc.cargarCliente(datos.lector.GetInt64(10));
                    sol.cliente = cli;

                    sol.estado = datos.lector.GetInt32(11);
                    if (sol.estado == 0)
                    {
                        sol.estadoLindo = "Rechazado";
                    }
                    else if (sol.estado == 1)
                    {
                        sol.estadoLindo = "Aprobado";
                    }
                    else
                    {
                        sol.estadoLindo = "Pendiente";
                    }

                    sol.observacion = prod.imagen = datos.lector.GetString(12);

                    listado.Add(sol);
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

        //METODO PARA VERIFICAR QUE SE PUEDA LLENAR LA SOLICITUD, QUE NO ESTE PENDIENTE LA ULTIMA QUE CREO --> 100%
        public bool verificarSolicitudUltima(long idCli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select top 1 s.estado from solicitud as s inner join producto as p on p.idProducto = s.idProducto inner join cliente as cl on cl.idCliente = p.idCliente where cl.idCliente =" +idCli+ " order by idSolicitud desc");
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    int estado = datos.lector.GetInt32(0);

                    if(estado==2)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO QUE GUARDA LA RAZON DEL RECHAZO DEL PRESTAMO --> 100%
        public void rechazarSolicitud(long idSol, String obser)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_rechazo_solicitud");
                datos.agregarParametro("@observacion", obser);
                datos.agregarParametro("@idSolicitud", idSol);
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

        //METODO QUE CAMBIA EL ESTADO DE LA SOLICITUD DE PENDIENTE -2- A APROBADA -1- --> 
        public void cambiarSoliDePendienteAAprobada(long idSol)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_cambiar_solicitud_a_aprobada");
                datos.agregarParametro("@idSolicitud", idSol);
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

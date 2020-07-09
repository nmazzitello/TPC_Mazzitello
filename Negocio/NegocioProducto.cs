using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioProducto
    {
        //METODO QUE GUARDA/ CREA EL PRODUCTO --> 100%
        public bool agregrarProducto(Producto pro, long idClli )
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_alta_producto");

                datos.agregarParametro("@idCLiente", idClli);
                datos.agregarParametro("@producto", pro.producto);
                datos.agregarParametro("@marca", pro.marca);
                datos.agregarParametro("@modelo", pro.modelo);
                datos.agregarParametro("@detalles", pro.detalles);
                datos.agregarParametro("@estado", pro.estado);
                datos.agregarParametro("@imagen", pro.imagen);
                datos.agregarParametro("@precio", pro.precio);

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

        //METODO QUE CARGA UNA LISTA CON TODOS LOS PRODUCTOS QUE TIENE EL CLIENTE CARGADOS --> 100%
        public List<Producto> traerProductos(long idCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Producto> listaProd = new List<Producto>();

            try
            {
                datos.setearSP("sp_cargar_producto");
                datos.agregarParametro("@idCliente", idCliente);
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    Producto prod = new Producto();

                    prod.idProducto = datos.lector.GetInt64(0);
                    prod.producto = datos.lector.GetString(1);
                    prod.marca = datos.lector.GetString(2);
                    prod.modelo = datos.lector.GetString(3);
                    prod.detalles = datos.lector.GetString(4);
                    prod.estado = datos.lector.GetString(5);
                    prod.imagen = datos.lector.GetString(6);
                    prod.precio= datos.lector.GetSqlMoney(7).ToString();

                    listaProd.Add(prod);
                }
                return listaProd;
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

        //METODO QUE CARGA UN PRODUCTO SEGUN SU ID --> 100%
        public Producto cargarProducto(long idProd)
        {
            AccesoDatos datos = new AccesoDatos();
            Producto prod = new Producto();

            try
            {
                datos.setearSP("sp_traer_producto");
                datos.agregarParametro("@idProducto", idProd);
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    prod.idProducto = datos.lector.GetInt64(0);
                    prod.producto = datos.lector.GetString(1);
                    prod.marca = datos.lector.GetString(2);
                    prod.modelo = datos.lector.GetString(3);
                    prod.detalles = datos.lector.GetString(4);
                    prod.estado = datos.lector.GetString(5);
                    prod.imagen = datos.lector.GetString(6);
                    prod.precio = datos.lector.GetSqlMoney(7).ToString();
                }
                return prod;
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

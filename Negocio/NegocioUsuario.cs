using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioUsuario
    {
        //METODO QUE CARGA EL USUARIO, SIEMPRE Y CUANDO COINCIDA EL USUARIO Y LA CONTRASEÑA INGRESADA --> 100%
        public Usuario cargarUsuario(String usuario, String contra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select u.idUsuario, u.usuario, u.contra, u.estado, tu.idTipoUsuario, tu.tipoUsuario from usuario as u inner join tipoUsuario as tu on tu.idTipoUsuario = u.idTipoUsuario where u.usuario ='" + usuario + "' and contra = '" + contra + "'");
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    Usuario user = new Usuario();
                    TipoUsuario tu = new TipoUsuario();

                    user.idUsuario= (int)datos.lector.GetInt64(0);
                    user.nombre = datos.lector.GetString(1);
                    user.contasenia= datos.lector.GetString(2);
                    user.activo=datos.lector.GetBoolean(3);

                    tu.idTipoUsuario = datos.lector.GetInt32(4);
                    tu.tipoUsuario = datos.lector.GetString(5);

                    user.tipoUsuario = tu;

                    return user;
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
            return null;
        }

        //SOBRE CARGA EL METODO QUE CARGA EL USUARIO, MEDIANTE EL IDCLIENTE --> 100%
        public Usuario cargarUsuario(long idCli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select u.idUsuario, u.usuario, u.contra, u.estado, tu.idTipoUsuario, tu.tipoUsuario from usuario as u inner join tipoUsuario as tu on tu.idTipoUsuario = u.idTipoUsuario where idUsuario="+idCli);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Usuario user = new Usuario();
                    TipoUsuario tu = new TipoUsuario();

                    user.idUsuario = (int)datos.lector.GetInt64(0);
                    user.nombre = datos.lector.GetString(1);
                    user.contasenia = datos.lector.GetString(2);
                    user.activo = datos.lector.GetBoolean(3);

                    tu.idTipoUsuario = datos.lector.GetInt32(4);
                    tu.tipoUsuario = datos.lector.GetString(5);

                    user.tipoUsuario = tu;

                    return user;
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
            return null;
        }

        //METODO QUE CREA UN USUARIO NUEVO --> 100%
        public void agregarUsuario(String usuario, String contra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_agregar_usuario");

                datos.agregarParametro("@usuario", usuario);
                datos.agregarParametro("@contra", contra);
                datos.agregarParametro("@estado", 1);
                datos.agregarParametro("@idTipoUsuario", 2);

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

        //METODO QUE BUSCA EL NUEVO NOMBRE DE USUARIO EN LA BASE DE DATOS, PARA VER SI ESTA DISPONIBLE, SI DEVUELVE FALSE, SE PUEDE USAR --> 100%
        public Boolean buscarNombreUsuario(String nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select * from usuario where usuario='"+ nombre +"'");
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    return true;
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
            return false;
        }

        //METODO QUE ELIMINA LOGICAMENTE AL USUARIO --> 100%
        public void eliminarUsuario(long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_eliminar_usuario");

                datos.agregarParametro("@idUsuario", idUsu);

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

        //METODO QUE CAMBIAR NOMBRE DEL USUARIO --> 0%
        public bool modificarNombreUsuario(String nombre, long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_modificar_nombre_usuario");
                datos.agregarParametro("@idUsuario", idUsu);
                datos.agregarParametro("@nombreNuevo", nombre);
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

        //METODO QUE CAMBIAR CONTRASEÑA DEL USUARIO --> 0%
        public void modificarContraUsuario(String contra, long idUsu)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_modificar_contrasenia_usuario");
                datos.agregarParametro("@idUsuario", idUsu);
                datos.agregarParametro("@contraNueva", contra);
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

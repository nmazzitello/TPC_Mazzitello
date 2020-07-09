using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTipoUsuario
    {
        //METODO QUE TRAE TODOS LOS DATOS DE UN DETERMINADO TIPO DE USUARIO --> 
        public TipoUsuario traerTipoUsuario(int idTipoUsu)
        {
            AccesoDatos datos = new AccesoDatos();
            TipoUsuario tu = new TipoUsuario();

            try
            {
                datos.setearQuery("select idTipoUsuario, tipoUsuario from tipoUsuario where idTipoUsuario=" + idTipoUsu);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {

                    tu.idTipoUsuario = datos.lector.GetInt32(0);
                    tu.tipoUsuario = datos.lector.GetString(1);
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
            return tu;
        }
    }
}

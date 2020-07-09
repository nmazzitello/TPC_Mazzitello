using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCliente
    {
        //METODO PARA GUARDAR LOS DATOS DE UN CLIENTE --> 100%
        public void guardarCliente(Cliente cli, long idCli)
        {
            AccesoDatos datos = new AccesoDatos();

            cli.fechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                datos.setearSP("sp_guardar_cliente");
                datos.agregarParametro("@idUsuario", idCli);
                datos.agregarParametro("@apellido", cli.apellido);
                datos.agregarParametro("@nombre", cli.nombre);
                datos.agregarParametro("@dni", cli.dni);
                datos.agregarParametro("@sexo", cli.sexo);
                datos.agregarParametro("@fechaNac", cli.fechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss"));
                datos.agregarParametro("@idNacionalidad", cli.nacionalidad.idNacionalidad);
                datos.agregarParametro("@domicilio", cli.datosDom.direccion);
                datos.agregarParametro("@idCiudad",cli.datosDom.ciudad.idCiudad);
                datos.agregarParametro("@telefonoPrin",cli.datosCont.telefonoPrinc);
                datos.agregarParametro("@telefonoAux", cli.datosCont.telefonoAux);
                datos.agregarParametro("@mail",cli.datosCont.mail);
                datos.agregarParametro("@trabaja",cli.datosLab.trabaja);
                datos.agregarParametro("@rubro", cli.datosLab.rubro);
                datos.agregarParametro("@sueldo", cli.datosLab.sueldo);
                datos.agregarParametro("@ingresoExtra", cli.datosLab.ingresoExtra);
                datos.agregarParametro("@razonIngExt", cli.datosLab.razonIngresoExtra);
                datos.agregarParametro("@montoIngExt", cli.datosLab.montoIngExt);

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

        //METODO PARA CARGAR UN OBJETO CLIENTE MEDIANTE EL USUARIO--> 100%
        public Cliente cargarCliente(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cli = new Cliente();

            try
            {
                datos.setearQuery("select c.idCliente, c.fechaReg, c.apellido, c.nombre, c.dni, c.sexo, c.fechaNac, c.idNacionalidad, c.activo from cliente as c inner join usuario as u on u.idUsuario = c.idUsuario where u.idUsuario ="+user.idUsuario);
                datos.ejecutarLector();

                if(datos.lector.Read())
                {
                    DatosDomicilio dd = new DatosDomicilio();
                    DatosContacto dc = new DatosContacto();
                    DatosLaborales dl = new DatosLaborales();

                    cli.idCliente = datos.lector.GetInt64(0);
                    cli.fechaRegistracion = datos.lector.GetDateTime(1);
                    cli.usuario = user;
                    cli.apellido = datos.lector.GetString(2);
                    cli.nombre = datos.lector.GetString(3);
                    cli.dni = datos.lector.GetString(4);
                    cli.sexo = datos.lector.GetString(5);
                    cli.fechaNacimiento = datos.lector.GetDateTime(6);

                    Nacionalidad nac = new Nacionalidad();
                    NegocioNacionalidad nn = new NegocioNacionalidad();
                    nac = nn.traerNac(datos.lector.GetInt32(7));
                    cli.nacionalidad = nac;

                    NegocioDatosDomicilio ndm = new NegocioDatosDomicilio();
                    dd = ndm.cargarDatosDomicilio(user.idUsuario);
                    cli.datosDom = dd;

                    NegocioDatosContacto ndc = new NegocioDatosContacto();
                    dc = ndc.cargarDatosCOntacto(user.idUsuario);
                    cli.datosCont = dc;

                    NegocioDatosLaborales ndl = new NegocioDatosLaborales();
                    dl = ndl.traerDatosLaborales(user.idUsuario);
                    cli.datosLab = dl;

                    cli.cantidadPrestamos = null;

                    cli.activo = datos.lector.GetBoolean(8);
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
            return cli;
        }

        //METODO QUE CONFIRMA SI ESTAN LOS CAMPOS EN CONDICIONES PARA GUARDAR AL CLIENTE --> 100%
        public bool sePuedeGuardar(Cliente cli)
        {
            if(cli.nombre.Equals("")|| cli.Equals("nombreVacio"))
            {
                return false;
            }
            else if (cli.apellido.Equals("") || cli.apellido.Equals("apellidoVacio"))
            {
                return false;
            }
            else if (cli.dni.Equals(""))
            {
                return false;
            }
            else if (cli.sexo.Equals("Pendiente") || cli.apellido.Equals("sexoVacio"))
            {
                return false;
            }
            else if (cli.fechaNacimiento.Equals("") || cli.apellido.Equals("1111-11-11"))
            {
                return false;
            }
            else if (cli.datosDom.direccion.Equals(""))
            {
                return false;
            }
            else if (cli.datosCont.telefonoPrinc.Equals("") || cli.datosCont.telefonoPrinc.Equals("telefonoVacio"))
            {
                return false;
            }
            else if (cli.datosCont.telefonoAux.Equals("") || cli.datosCont.telefonoAux.Equals("telefonoAuxVacio"))
            {
                return false;
            }
            else if (cli.datosCont.mail.Equals("") || cli.datosCont.mail.Equals("mailVacio"))
            {
                return false;
            }
            else if (cli.datosLab.trabaja==true)
            {
                if(cli.datosLab.rubro.Equals("") || cli.datosLab.Equals("Pendiente") || cli.datosLab.sueldo.Equals(""))
                {
                    return false;
                }
            }
            else if (cli.datosLab.ingresoExtra==true)
            {
                if(cli.datosLab.razonIngresoExtra.Equals("") || cli.datosLab.razonIngresoExtra.Equals("Pendiente") || cli.datosLab.montoIngExt.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        //METODO PARA CARGAR TODOS LOS CLIENTES EN UNA LISTA --> 100%
        public List<Cliente> traerClientes()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearQuery("select u.idUsuario, u.usuario, u.contra, u.estado, u.idTipoUsuario, c.fechaReg, c.apellido, c.nombre,c.dni, c.sexo, c.fechaNac, c.idNacionalidad  from usuario as u inner join cliente as c on c.idUsuario = U.idUsuario");
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    Cliente cli = new Cliente();
                    DatosDomicilio dd = new DatosDomicilio();
                    DatosContacto dc = new DatosContacto();
                    DatosLaborales dl = new DatosLaborales();

                    cli.idCliente = datos.lector.GetInt64(0);

                    cli.activo = datos.lector.GetBoolean(3);
                    if(cli.activo==true)
                    {
                        cli.activoLindo = "Activo";
                    }
                    else
                    {
                        cli.activoLindo = "Deshabilitado";
                    }

                    Usuario usu = new Usuario();
                    usu.idUsuario= datos.lector.GetInt64(0);
                    usu.nombre = datos.lector.GetString(1);
                    usu.contasenia = datos.lector.GetString(2);
                    usu.activo = datos.lector.GetBoolean(3);
                    TipoUsuario tu = new TipoUsuario();
                    NegocioTipoUsuario ntu = new NegocioTipoUsuario();
                    tu = ntu.traerTipoUsuario(datos.lector.GetInt32(4));
                    usu.tipoUsuario = tu;
                    cli.usuario = usu;

                    cli.fechaRegistracion = datos.lector.GetDateTime(5);
                    cli.apellido = datos.lector.GetString(6);
                    cli.nombre = datos.lector.GetString(7);
                    cli.dni = datos.lector.GetString(8);
                    cli.sexo = datos.lector.GetString(9);
                    cli.fechaNacimiento = datos.lector.GetDateTime(10);

                    Nacionalidad nac = new Nacionalidad();
                    NegocioNacionalidad nn = new NegocioNacionalidad();
                    nac = nn.traerNac(datos.lector.GetInt32(11));
                    cli.nacionalidad = nac;

                    NegocioDatosDomicilio ndm = new NegocioDatosDomicilio();
                    dd = ndm.cargarDatosDomicilio(datos.lector.GetInt64(0));
                    cli.datosDom = dd;

                    NegocioDatosContacto ndc = new NegocioDatosContacto();
                    dc = ndc.cargarDatosCOntacto(datos.lector.GetInt64(0));
                    cli.datosCont = dc;

                    NegocioDatosLaborales ndl = new NegocioDatosLaborales();
                    dl = ndl.traerDatosLaborales(datos.lector.GetInt64(0));
                    cli.datosLab = dl;

                    cli.cantidadPrestamos = null;
                    lista.Add(cli);
                }
                return lista;
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

        //METODO PARA VERIFICAR QUE SE PUEDA DAR UN PRESTAMO A CLIENTE -TODOS LOS DATOS CARGADOS- -->
        public bool listoParaPrimerCredito(Cliente cli)
        {
            //AccesoDatos datos = new AccesoDatos();

            if (cli.apellido.Equals("apellidoVacio"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //METODO PARA CARGAR UN CLIENTE EN SESION MEDIANTE SU ID --> 100%
        public Cliente cargarCliente(long idCli)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cli = new Cliente();

            try
            {
                datos.setearQuery("select c.idCliente, c.fechaReg, c.apellido, c.nombre, c.dni, c.sexo, c.fechaNac, c.idNacionalidad, c.activo from cliente as c inner join usuario as u on u.idUsuario = c.idUsuario where c.idCliente =" + idCli);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    DatosDomicilio dd = new DatosDomicilio();
                    DatosContacto dc = new DatosContacto();
                    DatosLaborales dl = new DatosLaborales();

                    cli.idCliente = datos.lector.GetInt64(0);
                    cli.fechaRegistracion = datos.lector.GetDateTime(1);

                    NegocioUsuario nu = new NegocioUsuario();
                    Usuario user = nu.cargarUsuario(idCli);
                    cli.usuario = user;
                    cli.apellido = datos.lector.GetString(2);
                    cli.nombre = datos.lector.GetString(3);
                    cli.dni = datos.lector.GetString(4);
                    cli.sexo = datos.lector.GetString(5);
                    cli.fechaNacimiento = datos.lector.GetDateTime(6);

                    Nacionalidad nac = new Nacionalidad();
                    NegocioNacionalidad nn = new NegocioNacionalidad();
                    nac = nn.traerNac(datos.lector.GetInt32(7));
                    cli.nacionalidad = nac;

                    NegocioDatosDomicilio ndm = new NegocioDatosDomicilio();
                    dd = ndm.cargarDatosDomicilio(user.idUsuario);
                    cli.datosDom = dd;

                    NegocioDatosContacto ndc = new NegocioDatosContacto();
                    dc = ndc.cargarDatosCOntacto(user.idUsuario);
                    cli.datosCont = dc;

                    NegocioDatosLaborales ndl = new NegocioDatosLaborales();
                    dl = ndl.traerDatosLaborales(user.idUsuario);
                    cli.datosLab = dl;

                    cli.cantidadPrestamos = null;

                    cli.activo = datos.lector.GetBoolean(8);
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
            return cli;
        }

        //METODO PARA CARGAR AL CLIENTE DUEÑO DEL PRODCUTO -->  ver
        public Cliente cargarClientePorProducto(long idProd)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cli = new Cliente();

            try
            {
                datos.setearQuery("select c.idCliente, c.fechaReg, c.apellido, c.nombre, c.dni, c.sexo, c.fechaNac, c.idNacionalidad, c.activo from cliente as c inner join producto as p on p.idCliente = c.idCliente where p.idProducto ="+ idProd);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    DatosDomicilio dd = new DatosDomicilio();
                    DatosContacto dc = new DatosContacto();
                    DatosLaborales dl = new DatosLaborales();

                    cli.idCliente = datos.lector.GetInt64(0);
                    cli.fechaRegistracion = datos.lector.GetDateTime(1);

                    NegocioUsuario nu = new NegocioUsuario();
                    Usuario user = nu.cargarUsuario(datos.lector.GetInt64(0));
                    cli.usuario = user;
                    cli.apellido = datos.lector.GetString(2);
                    cli.nombre = datos.lector.GetString(3);
                    cli.dni = datos.lector.GetString(4);
                    cli.sexo = datos.lector.GetString(5);
                    cli.fechaNacimiento = datos.lector.GetDateTime(6);

                    Nacionalidad nac = new Nacionalidad();
                    NegocioNacionalidad nn = new NegocioNacionalidad();
                    nac = nn.traerNac(datos.lector.GetInt32(7));
                    cli.nacionalidad = nac;

                    NegocioDatosDomicilio ndm = new NegocioDatosDomicilio();
                    dd = ndm.cargarDatosDomicilio(user.idUsuario);
                    cli.datosDom = dd;

                    NegocioDatosContacto ndc = new NegocioDatosContacto();
                    dc = ndc.cargarDatosCOntacto(user.idUsuario);
                    cli.datosCont = dc;

                    NegocioDatosLaborales ndl = new NegocioDatosLaborales();
                    dl = ndl.traerDatosLaborales(user.idUsuario);
                    cli.datosLab = dl;

                    cli.cantidadPrestamos = null;

                    cli.activo = datos.lector.GetBoolean(8);
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
            return cli;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominios;

namespace Conexiones
{
    public class ConexionUsers

    {
        public bool Loguear(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from Users where email = @email and pass = @pass");
                datos.SetearParametro("@email", user.Email);
                datos.SetearParametro("@pass", user.Pass);

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                        user.TipoUsuario = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    //user.TipoUsuario = (datos.Lector["admin"].ToString() == "1") ? Admin.Admin : Admin.Normal;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public static void actualizar(User user)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Update USERS set urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido Where Id = @id");
                datos.SetearParametro("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);
                //datos.SetearParametro("@imagen", user.UrlImagenPerfil != null ? user.UrlImagenPerfil : "");
                datos.SetearParametro("@id", user.Id);
                datos.SetearParametro("@nombre", user.Nombre);
                datos.SetearParametro("@apellido", user.Apellido);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }        
        }   

        public int crearUsuario(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearconSp("nuevoUser");
                datos.SetearParametro("@email", user.Email);
                datos.SetearParametro("@pass", user.Pass);
                return datos.ejecutarAccionScalar();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

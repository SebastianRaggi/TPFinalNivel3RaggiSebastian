
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominios;
using System.Configuration;

namespace Conexiones
{
    public class ConexionArticulo
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            //AccesoDatos datos = new AccesoDatos();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                
                conexion.ConnectionString = ConfigurationManager.AppSettings["cadenaConexion"];
                //conexion.ConnectionString = "Server = .\\SQLEXPRESS; database = CATALOGO_WEB_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id ";
                //datos.SetearConsulta("select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id");
                //datos.EjecutarLectura();
                if (id != "")
                    comando.CommandText += "and A.Id = " + id;
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo Aux = new Articulo();
                    Aux.Id = (int)lector["Id"];
                    Aux.Codigo = (string)lector[0];
                    Aux.Nombre = (string)lector["Nombre"];
                    Aux.Descripcion = (string)lector[2];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Id = (int)lector["IdCategoria"];
                    Aux.Categorias.Descripcion = (string)lector[3];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Id = (int)lector["IdMarca"];
                    Aux.Marcas.Descripcion = (string)lector[4];
                    Aux.ImagenUrl = (string)lector[5];
                    Aux.Precio = (decimal)lector[6];

                    lista.Add(Aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                //string consulta = "select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id";

                //datos.SetearConsulta(consulta);
                //datos.EjecutarLectura();

                datos.setearconSp("storedListar");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo Aux = new Articulo();
                    Aux.Id = (int)datos.Lector["Id"];
                    Aux.Codigo = (string)datos.Lector[0];
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector[2];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Id = (int)datos.Lector["IdCategoria"];
                    Aux.Categorias.Descripcion = (string)datos.Lector[3];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Id = (int)datos.Lector["IdMarca"];
                    Aux.Marcas.Descripcion = (string)datos.Lector[4];
                    Aux.ImagenUrl = (string)datos.Lector[5];
                    Aux.Precio = (decimal)datos.Lector[6];


                    lista.Add(Aux);



                }
                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into ARTICULOS  values ( @Codigo , @Nombre , @Descripcion , @idMarca , @idCategoria , @ImagenUrl , @Precio )");
                datos.SetearParametro("@Codigo", nuevo.Codigo);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@idMarca", nuevo.Marcas.Id);
                datos.SetearParametro("@idCategoria", nuevo.Categorias.Id);
                datos.SetearParametro("@Precio", nuevo.Precio);
                datos.SetearParametro("@ImagenUrl", nuevo.ImagenUrl);
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

        public void agregarArticuloconSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearconSp("storedAltaArticulos");
                datos.SetearParametro("@Codigo", nuevo.Codigo);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@idMarca", nuevo.Marcas.Id);
                datos.SetearParametro("@idCategoria", nuevo.Categorias.Id);
                datos.SetearParametro("@Precio", nuevo.Precio);
                datos.SetearParametro("@ImagenUrl", nuevo.ImagenUrl);
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

        public void modificarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio  where Id = @Id");
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@idMarca", articulo.Marcas.Id);
                datos.SetearParametro("@idCategoria", articulo.Categorias.Id);
                datos.SetearParametro("@Precio", articulo.Precio.ToString("C0"));
                datos.SetearParametro("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametro("@Id", articulo.Id);
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
        public void ModificarArticuloConSP(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearconSp("storedModificarArticulo");
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@idMarca", articulo.Marcas.Id);
                datos.SetearParametro("@idCategoria", articulo.Categorias.Id);
                datos.SetearParametro("@Precio", articulo.Precio);
                datos.SetearParametro("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametro("@Id", articulo.Id);
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
        public void EliminarArticulo(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS where id = @Id");
                datos.SetearParametro("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = "select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id And ";

                switch (campo)
                {
                    case "Categoria":

                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "c.Descripcion like '%" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "c.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                
                                consulta += "c.Descripcion like '" + filtro + "%'";
                                break;

                        }
                        break;


                    case "Marca":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;


                    case "Precio":
                        switch (criterio)

                        {
                            case "Igual a":
                                consulta += "Precio =" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio <" + filtro;
                                break;
                            default:
                                consulta += "Precio >" + filtro;
                                break;
                        }

                        break;


                }

                datos.SetearConsulta(consulta);

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo Aux = new Articulo();
                    Aux.Id = (int)datos.Lector["Id"];
                    Aux.Codigo = (string)datos.Lector[0];
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector[2];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Id = (int)datos.Lector["IdCategoria"];
                    Aux.Categorias.Descripcion = (string)datos.Lector[3];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Id = (int)datos.Lector["IdMarca"];
                    Aux.Marcas.Descripcion = (string)datos.Lector[4];
                    Aux.ImagenUrl = (string)datos.Lector[5];
                    Aux.Precio = (decimal)datos.Lector[6];

                    lista.Add(Aux);



                }
                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }



}

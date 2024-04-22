using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexiones;
using Dominios;


namespace WebApp
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    ConexionCategoria categoria = new ConexionCategoria();
                    ConexionMarca marca = new ConexionMarca();
                    List<Marcas> listamarcas = marca.listar();
                    Session["listamarcas"] = listamarcas;


                    ddlMarca.DataSource = listamarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    List<Categorias> listacategorias = categoria.listar();
                    ddlCategoria.DataSource = listacategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ConexionArticulo articulo = new ConexionArticulo();
                    //List<Articulo> lista = conexion.listar(Request.QueryString["id"].ToString());
                    Articulo seleccionado = (articulo.listar(id))[0];


                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString("0");
                    txtImage.Text = seleccionado.ImagenUrl;
                    ddlCategoria.SelectedValue = seleccionado.Categorias.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marcas.Id.ToString();

                    txtImage_TextChanged(sender, e);

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Articulo nuevo = new Articulo();
                ConexionArticulo conexion = new ConexionArticulo();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Marcas = new Marcas();
                nuevo.Marcas.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categorias = new Categorias();
                nuevo.Categorias.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.ImagenUrl = txtImage.Text;
                
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    conexion.ModificarArticuloConSP(nuevo);
                }
                else
                {
                    
                    conexion.agregarArticuloconSP(nuevo);
                }


                Response.Redirect("Lista de Articulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

                throw ex;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(ddlCategoria.SelectedItem.Value);
            ddlMarca.DataSource = ((List<Marcas>)Session["listamarcas"]).FindAll(x => x.Id == Id);
            ddlMarca.DataBind();
        }

        protected void txtImage_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImage.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {

                    ConexionArticulo conexion = new ConexionArticulo();
                    conexion.EliminarArticulo(int.Parse(txtId.Text));
                    Response.Redirect("Lista de Articulos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}
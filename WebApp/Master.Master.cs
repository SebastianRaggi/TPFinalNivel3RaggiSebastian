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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/vector-flat-illustration-grayscale-avatar-260nw-2281862025.jpg";
            if (!(Page is Login || Page is Registro || Page is Error))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                {
                    if (!(Page is Default || Page is DetalleArticulo))
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
                else
                {
                    User user = (User)Session["usuario"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Imagenes/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
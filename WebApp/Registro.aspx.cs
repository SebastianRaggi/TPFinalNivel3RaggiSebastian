using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominios;
using Conexiones;

namespace WebApp
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                ConexionUsers conexionUsers = new ConexionUsers();
                            
                user.Email = txtCorreo.Text;
                user.Pass = txtPassword.Text;
                user.Id = conexionUsers.crearUsuario(user);
                Session.Add("usuario", user);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Promocioncomercio
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvTerminos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ckbTersYCond.Checked;
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Cliente nuevoCliente = new Cliente();
                    nuevoCliente.Documento = tbxDNI.Text;
                    nuevoCliente.Nombre = tbxNombre.Text;
                    nuevoCliente.Apellido = tbxApellido.Text;
                    nuevoCliente.Email = tbxEmail.Text;
                    nuevoCliente.Direccion = tbxDireccion.Text;
                    nuevoCliente.Ciudad = tbxCiudad.Text;
                    nuevoCliente.CP = int.Parse(tbxCP.Text);

                    ClienteNegocio negocio = new ClienteNegocio();
                    negocio.Agregar(nuevoCliente);

                    // Redirigir a la página de éxito
                    Response.Redirect("Exito.aspx");
                }
                catch (Exception ex)
                {
                    // Manejar el error (puedes mostrar un mensaje al usuario)
                    // Por ahora, solo se lanza la excepción
                    throw ex;
                }
            }
        }
    }
}
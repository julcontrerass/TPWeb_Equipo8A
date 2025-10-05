using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using accesoDatos;

namespace Promocioncomercio
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string codigoIngresado = TextBox1.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                TextBox1.CssClass = "input-error";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMsg", "document.getElementById('errorCodigo').textContent = 'Debe ingresar un código';" + "document.getElementById('errorCodigo').style.display = 'block';", true);
                return;
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@codigo", codigoIngresado);

                object resultado = datos.ejecutarScalar();
                int cantidad = Convert.ToInt32(resultado);

                if (cantidad > 0)
                {
                    TextBox1.CssClass = "input-valid";
                    Response.Redirect("seleccionarProducto.aspx");
                }
                else
                {
                    TextBox1.CssClass = "input-error";
                    ScriptManager.RegisterStartupScript(this, GetType(), "errorMsg", "document.getElementById('errorCodigo').textContent = 'El código ingresado no es válido';" + "document.getElementById('errorCodigo').style.display = 'block';" + "mostrarToast('El código ingresado no es válido', 'error');", true);
                }
            }
            catch (Exception)
            {
                TextBox1.CssClass = "input-error";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMsg","document.getElementById('errorCodigo').textContent = 'Estamos en mantenimiento actualmente. Intente más tarde.';" + "document.getElementById('errorCodigo').style.display = 'block';" + "mostrarToast('Estamos en mantenimiento actualmente. Intente más tarde.', 'error');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
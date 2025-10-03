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
            string codigoIngresado = TextBox1.Text.Trim();//trim para eliminar espacios en blanco
            if (string.IsNullOrEmpty(codigoIngresado))
            {
                lblMensaje.Text = "Debe ingresar un código";
                return;
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta a la tabla Vouchers con la columna CodigoVoucher
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.Comando.Parameters.Clear();
                datos.Comando.Parameters.AddWithValue("@codigo", codigoIngresado);

                object resultado = datos.ejecutarScalar();
                int cantidad = Convert.ToInt32(resultado);

                if (cantidad > 0)
                {
                    //si el codigo está en la bdd, entonces vamos a la pagina
                    Response.Redirect("seleccionarProducto.aspx");
                }
                else
                {
                    //si el codigo no está en la bdd, mostramos este cartel
                    lblMensaje.Text = "El código ingresado no es válido";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Estamos en mantenimiento actualmente. Intente más tarde.";
                // opcional: guardar el error en un log
                System.Diagnostics.Debug.WriteLine("Error en Default.aspx: " + ex.ToString());

            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
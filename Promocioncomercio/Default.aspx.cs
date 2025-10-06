using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

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
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            try
            {
                // Verificar que el voucher existe Y que no haya sido usado
                if (voucherNegocio.ExisteYNoUsado(codigoIngresado))
                {
                    // Guardar el código en Session para usarlo después
                    Session["CodigoVoucher"] = codigoIngresado;

                    //si el codigo está en la bdd y no fue usado, vamos a la pagina
                    Response.Redirect("seleccionarProducto.aspx");
                }
                else
                {
                    // Verificar si el código existe pero ya fue usado
                    if (voucherNegocio.Existe(codigoIngresado))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "toast", "mostrarToast('Este código ya fue utilizado', 'error');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "toast", "mostrarToast('El código ingresado no es válido', 'error');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "toast", "mostrarToast('Estamos en mantenimiento actualmente. Intente más tarde.', 'error');", true);
                // opcional: guardar el error en un log
                System.Diagnostics.Debug.WriteLine("Error en Default.aspx: " + ex.ToString());
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using dominio;
using negocio;
using System.Web.Script.Services;

namespace Promocioncomercio
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar el TextChanged del DNI para que dispare el evento
                tbxDNI.AutoPostBack = true;
            }
        }

        protected void tbxDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = tbxDNI.Text.Trim();

            // Validar que el DNI no esté vacío y sea numérico
            if (string.IsNullOrEmpty(dni) || !System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d+$"))
            {
                return;
            }

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.BuscarPorDNI(dni);

                if (cliente != null)
                {
                    // Pre-cargar los datos del cliente
                    tbxNombre.Text = cliente.Nombre;
                    tbxApellido.Text = cliente.Apellido;
                    tbxEmail.Text = cliente.Email;
                    tbxDireccion.Text = cliente.Direccion;
                    tbxCiudad.Text = cliente.Ciudad;
                    tbxCP.Text = cliente.CP.ToString();
                    
                   
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Cliente encontrado. Los datos han sido pre-cargados.');", true);
                }
                else
                {
                    // Limpiar todos los campos si el DNI no existe
                    tbxNombre.Text = string.Empty;
                    tbxApellido.Text = string.Empty;
                    tbxEmail.Text = string.Empty;
                    tbxDireccion.Text = string.Empty;
                    tbxCiudad.Text = string.Empty;
                    tbxCP.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", $"alert('Error al buscar cliente: {ex.Message}');", true);
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
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

                // Enviar mail de confirmación
                EmailService servicioEmail = new EmailService();
                servicioEmail.armarCorreo(
                    nuevoCliente.Email,
                    "Confirmación de Participación",
                    $"Hola {nuevoCliente.Nombre} {nuevoCliente.Apellido},<br/><br/>" +
                    $"Nos pondremos en contacto para entregarte el producto que canjeaste.");
                servicioEmail.enviarCorreo();

                // Redirigir a la página de éxito
                Response.Redirect("Exito.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (FormatException ex)
            {
                throw new Exception("Error: El formato del CP no es válido. Debe ser un número entero.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el cliente en la base de datos: " + ex.Message, ex);
            }
        }

    }
}
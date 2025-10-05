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

                    ScriptManager.RegisterStartupScript(this, GetType(), "toast", "mostrarToast('Cliente encontrado. Los datos han sido pre-cargados.', 'info');", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "toast", $"mostrarToast('Error al buscar cliente: {ex.Message}', 'error');", true);
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el código de voucher de Session
                string codigoVoucher = Session["CodigoVoucher"] as string;
                if (string.IsNullOrEmpty(codigoVoucher))
                {
                    throw new Exception("No se encontró el código de voucher. Por favor, inicie el proceso nuevamente.");
                }

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente nuevoCliente = new Cliente();

                // Verificar si el DNI ya existe en la base de datos
                Cliente clienteExistente = negocio.BuscarPorDNI(tbxDNI.Text.Trim());

                // Solo agregar el cliente si no existe en la base de datos
                if (clienteExistente == null)
                {
                    nuevoCliente.Documento = tbxDNI.Text;
                    nuevoCliente.Nombre = tbxNombre.Text;
                    nuevoCliente.Apellido = tbxApellido.Text;
                    nuevoCliente.Email = tbxEmail.Text;
                    nuevoCliente.Direccion = tbxDireccion.Text;
                    nuevoCliente.Ciudad = tbxCiudad.Text;
                    nuevoCliente.CP = int.Parse(tbxCP.Text);

                    negocio.Agregar(nuevoCliente);

                    // Obtener el Id del cliente recién creado
                    clienteExistente = negocio.BuscarPorDNI(tbxDNI.Text.Trim());
                    nuevoCliente = clienteExistente;
                }
                else
                {
                    nuevoCliente = clienteExistente; // Usar el cliente existente
                }

                string productoIdStr = Request.QueryString["productoId"];
                int productoId = 0;
                if (!string.IsNullOrEmpty(productoIdStr))
                {
                    productoId = int.Parse(productoIdStr);
                }

                // Actualizar el voucher existente
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.ActualizarVoucher(codigoVoucher, nuevoCliente.Id, productoId);

                // Enviar mail de confirmación
                EmailService servicioEmail = new EmailService();
                servicioEmail.armarCorreo(
                    nuevoCliente.Email,
                    "Confirmación de Participación",
                    $"Hola {nuevoCliente.Nombre} {nuevoCliente.Apellido},<br/><br/>" +
                    $"Nos pondremos en contacto para entregarte el producto que canjeaste.<br/><br/>" +
                    $"Tu código de voucher es: <strong>{codigoVoucher}</strong>");
                servicioEmail.enviarCorreo();

                // Limpiar la session
                Session.Remove("CodigoVoucher");

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
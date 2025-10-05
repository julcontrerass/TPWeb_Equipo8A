using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Promocioncomercio
{
    public partial class Contact : Page
    {

        public List<Producto> ListadoProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              ProductoNegocio negocio = new ProductoNegocio();
              ListadoProductos = negocio.buscarProductos();
               
            }

        }
    }
}
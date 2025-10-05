using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class ProductoNegocio
    {
        private AccesoDatos datos; 
        public ProductoNegocio() { 
        
            datos = new AccesoDatos();
        }

        private List<Producto> listaProductos = new List<Producto>();

        public List<Producto> buscarProductos()
        {
            Producto producto = null;  

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion as Marca, I.ImagenUrl from ARTICULOS A left join MARCAS M ON  A.IdMarca = M.Id  left join IMAGENES I ON  A.ID = I.IdArticulo");
                datos.ejecutarLectura();

                int? idProdAnterior = null;

                while (datos.Lector.Read())
                {


                    int idProductoActual = (int)datos.Lector["Id"];
                   
                    if(idProductoActual == idProdAnterior)
                    {
                        continue;
                    }

                    producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Codigo = (string)datos.Lector["Codigo"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["precio"];
                    producto.Marca = (string)datos.Lector["Marca"];
                    string UrlImg = (string)datos.Lector["ImagenUrl"];
                    ImagenService imagenService = new ImagenService();
                    List<Imagen> listaImagenes = imagenService.Listar(producto.Id);
                    producto.imagenes = listaImagenes;
                    idProdAnterior = producto.Id;

                    listaProductos.Add(producto);
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al buscar un producto: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaProductos;
        }




    }
}

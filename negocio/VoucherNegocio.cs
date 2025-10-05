using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;

namespace negocio
{
    public class VoucherNegocio
    {
        private AccesoDatos datos;

        public VoucherNegocio()
        {
            datos = new AccesoDatos();
        }

        public bool ExisteYNoUsado(string codigoVoucher)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo AND FechaCanje IS NULL");
                datos.setearParametro("@codigo", codigoVoucher);

                object resultado = datos.ejecutarScalar();
                int cantidad = Convert.ToInt32(resultado);

                return cantidad > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Existe(string codigoVoucher)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.setearParametro("@codigo", codigoVoucher);

                object resultado = datos.ejecutarScalar();
                int cantidad = Convert.ToInt32(resultado);

                return cantidad > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Voucher nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO Vouchers (CodigoVoucher, IdCliente, FechaCanje, IdArticulo) VALUES (@CodigoVoucher, @IdCliente, @FechaCanje, @IdArticulo)");
                datos.setearParametro("@CodigoVoucher", nuevo.CodigoVoucher);
                datos.setearParametro("@IdCliente", nuevo.IdCliente);
                datos.setearParametro("@FechaCanje", nuevo.FechaCanje);
                datos.setearParametro("@IdArticulo", nuevo.IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ActualizarVoucher(string codigoVoucher, int idCliente, int idArticulo)
        {
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigoVoucher);
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@FechaCanje", DateTime.Now);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

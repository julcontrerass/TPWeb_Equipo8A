using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesoDatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public SqlCommand Comando
        {
            get { return comando; }
        }


        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security=true");
            //conexion = new SqlConnection("server=192.168.1.17,1433; database=PROMOS_DB;User Id=SA;Password=m^@DfCT8&Y");


            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
            comando.Parameters.Clear(); 
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public object ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de SQL al ejecutar scalar: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar scalar en la base de datos: " + ex.Message, ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de SQL al ejecutar la acción: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar acción en la base de datos: " + ex.Message, ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}

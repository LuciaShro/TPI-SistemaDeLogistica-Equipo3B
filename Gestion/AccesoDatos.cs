using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    internal class AccesoDatos
    {
        
            private SqlConnection conexion;
            private SqlCommand comando;
            private SqlDataReader lector;
            public SqlDataReader Lector
            {
                get
                {
                    return lector;
                }
            }


            public AccesoDatos()
            {
                conexion = new SqlConnection("server=.\\SQLEXPRESS; database=flashShip; integrated security=true;");
                comando = new SqlCommand();

            }

            public void setearConsulta(string consulta)
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }

            public void ejecutarLectura()
            {
                comando.Connection = conexion;
                try
                {
                    conexion.Open();
                    lector = comando.ExecuteReader(); //tabla 
                }
                catch (Exception ex)
                {
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void setearParametro(string nombre, object valor)
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }

            public void cerrarConexion()
            {
                if (lector != null)
                    lector.Close();
                conexion.Close();

            }

            public object obtenerValor()
            {
            comando.Connection = conexion;
            conexion.Open();
            object valor = comando.ExecuteScalar(); 
            return valor;
            }

    }
}

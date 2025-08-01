﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public class AccesoDatos
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

        public SqlConnection Conexion
        {
            get { return conexion; }
        }

        public SqlCommand Comando
        {
            get { return comando; }
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
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                lector = comando.ExecuteReader(); //tabla 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ejecutarLectura: " + ex.Message);
                throw;
            }

        }

        /* public void ejecutarAccion()
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
         }*/
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                    conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void abrirConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();
        }


        public SqlTransaction iniciarTransaccion()
        {
            return conexion.BeginTransaction();
        }


        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();

        }

        /* public object obtenerValor()
         {
         return Comando.ExecuteScalar();
         } */

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearProcedimiento_(string nombreProcedimiento)
        {
            comando = new SqlCommand(nombreProcedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
        }


        public object obtenerValor()
        {
            comando.Connection = conexion;

            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en obtenerValor: " + ex.Message);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public object obtenerValorSinCerrarConexion()
        {
            comando.Connection = conexion;

            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en obtenerValor: " + ex.Message);
                throw;
            }
        }

        public object ejecutarScalar()
        {
            comando.Connection = conexion;
            conexion.Open();
            return comando.ExecuteScalar();
        }
    }
}

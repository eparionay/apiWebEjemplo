using apiWebEjemplo.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.dao.daoImpl
{
    public class AlumnoDaoImpl : AlumnoDao
    {

        private static readonly ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Alumno> listadoAlumno(string indicador, int codigo)
        {
            List<Alumno> lista = new List<Alumno>();
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionPrueba"].ConnectionString);
            SqlCommand cmd;
            SqlDataReader reader;
            try
            {
                sqlCon.Open();
                cmd = new SqlCommand("usp_alumno_crud", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@indicador", indicador);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Nombre", "");
                cmd.Parameters.AddWithValue("@ApellidoPaterno", "");
                cmd.Parameters.AddWithValue("@ApellidoMaterno", "");
                cmd.Parameters.AddWithValue("@Genero", "");
                cmd.Parameters.AddWithValue("@Documento", "");

                reader = cmd.ExecuteReader();
                Alumno objAlumno;
                
                while (reader.Read())
                {
                    objAlumno = new Alumno();
                    objAlumno.Codigo = reader.GetInt32(0);
                    objAlumno.Nombre= reader.GetString(1);
                    objAlumno.ApellidoPaterno = reader.GetString(2);
                    objAlumno.ApellidoMaterno = reader.GetString(3);
                    objAlumno.Genero = reader.GetString(4);
                    objAlumno.Documento = reader.GetString(5);
                    objAlumno.Estado = reader.GetInt32(6);
                    lista.Add(objAlumno);
                }
            }
            catch (Exception ex)
            {
                LOG.Error("listadoAlumno - Error : " + ex.Message );
            }
            finally
            {
                sqlCon.Close();
            }
            return lista;
        }

        // Registrar, Actualizar y Eliminar
        public int operacionAlumno(string indicador, Alumno objAlumno)
        {
            int registrar = -1;
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionPrueba"].ConnectionString);
            SqlCommand sqlCommand;
            try
            {
                sqlCon.Open();
                sqlCommand = new SqlCommand("usp_alumno_crud", sqlCon);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.AddWithValue("@indicador", indicador);
                sqlCommand.Parameters.AddWithValue("@Codigo", objAlumno.Codigo);
                sqlCommand.Parameters.AddWithValue("@Nombre", objAlumno.Nombre);
                sqlCommand.Parameters.AddWithValue("@ApellidoPaterno", objAlumno.ApellidoPaterno);
                sqlCommand.Parameters.AddWithValue("@ApellidoMaterno", objAlumno.ApellidoMaterno);
                sqlCommand.Parameters.AddWithValue("@Genero", objAlumno.Genero);
                sqlCommand.Parameters.AddWithValue("@Documento", objAlumno.Documento);
                registrar = Convert.ToInt32(sqlCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                LOG.Error("registrarAlumno - Error : " + ex.Message);
            }finally
            {
                sqlCon.Close(); 
            }
            return registrar;
        }


    }
}
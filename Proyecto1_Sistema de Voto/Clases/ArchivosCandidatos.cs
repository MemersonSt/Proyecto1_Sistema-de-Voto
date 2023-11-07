using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Windows;

namespace Proyecto1_Sistema_de_Voto.clases
{
    public static class ArchivosCandidatos
    {
        private static readonly string directoryPath = "ArchivosCandidatos";


        #region Create
        public static void CreateCandidate(Candidato candidato)
        {
            try
            {
                string sSentenciaSql = "INSERT INTO CANDIDATO (CEDULA, NOMBRE, LISTA, MAIL, ESTADO)";
                sSentenciaSql = sSentenciaSql + "VALUES (@CEDULA, @NOMBRE, @LISTA, @MAIL, @ESTADO)";
                SqlConnection conexion = ConexionBD.GetConnection();
                SqlCommand comando = new SqlCommand(sSentenciaSql, conexion);

                comando.Parameters.AddWithValue("@CEDULA", candidato._sCEDULA);
                comando.Parameters.AddWithValue("@NOMBRE", candidato._sNOMBRE);
                comando.Parameters.AddWithValue("@LISTA", candidato._sLISTA);
                comando.Parameters.AddWithValue("@MAIL", candidato._sMAIL);
                comando.Parameters.AddWithValue("@ESTADO", candidato._sESTADO);

                comando.ExecuteNonQuery();
                ConexionBD.CloseConnection(conexion);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el usuario: {e.Message}");
            }
        }
        #endregion

        #region Read
        public static Candidato ReadCandidateByCedula(string cedula)
        {
            Candidato candidato = new Candidato();

            try
            {
                var conn = ConexionBD.GetConnection();
                string sQuery = "SELECT * FROM CANDIDATO WHERE CEDULA = '" + cedula + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows[0]["CEDULA"].ToString() == cedula)
                {
                    candidato._sCEDULA = dataSet.Tables[0].Rows[0]["CEDULA"].ToString();
                    candidato._sNOMBRE = dataSet.Tables[0].Rows[0]["NOMBRE"].ToString();
                    candidato._sLISTA = dataSet.Tables[0].Rows[0]["LISTA"].ToString();
                    candidato._sMAIL = dataSet.Tables[0].Rows[0]["MAIL"].ToString();
                    candidato._sESTADO = dataSet.Tables[0].Rows[0]["ESTADO"].ToString();
                    candidato._dFECHA_CREACION = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["FECHA_CREACION"]);
                    
                }
                ConexionBD.CloseConnection(conn);

                return candidato;
            }
            catch (SqlTypeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error de: {e.Message}");
            }

            return candidato;
        }
        #endregion

        #region Update
        public static void UpdateCandidate(Candidato candidato)
        {
            SqlConnection connection = ConexionBD.GetConnection();
            string sql = "SELECT * FROM CANDIDATO WHERE CEDULA = '" + candidato._sCEDULA + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows[0]["CEDULA"].ToString() == candidato._sCEDULA)
            {


                string sSentenciaSql = "UPDATE CANDIDATO ";
                sSentenciaSql = sSentenciaSql + "SET NOMBRE = @NOMBRE, ";
                sSentenciaSql = sSentenciaSql + "LISTA = @LISTA, ";
                sSentenciaSql = sSentenciaSql + "MAIL = @MAIL, ";
                sSentenciaSql = sSentenciaSql + "ESTADO = @ESTADO ";
                sSentenciaSql = sSentenciaSql + "WHERE CEDULA = @CEDULA";
                SqlConnection conexion = ConexionBD.GetConnection();
                SqlCommand comando = new SqlCommand(sSentenciaSql, conexion);

                comando.Parameters.AddWithValue("@CEDULA", candidato._sCEDULA);
                comando.Parameters.AddWithValue("@NOMBRE", candidato._sNOMBRE);
                comando.Parameters.AddWithValue("@LISTA", candidato._sLISTA);
                comando.Parameters.AddWithValue("@MAIL", candidato._sMAIL);
                comando.Parameters.AddWithValue("@ESTADO", candidato._sESTADO);

                comando.ExecuteNonQuery();
                ConexionBD.CloseConnection(conexion);
            }
        }
        #endregion

        #region Delete
        public static void DeleteCandidate(Candidato candidato)
        {
            SqlConnection connection = ConexionBD.GetConnection();
            string sql = "SELECT * FROM CANDIDATO WHERE CEDULA = '" + candidato._sCEDULA + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows[0]["CEDULA"].ToString() == candidato._sCEDULA)
            {


                string sSentenciaSql = "UPDATE CANDIDATO ";
                sSentenciaSql = sSentenciaSql + "SET ESTADO = @ESTADO ";
                sSentenciaSql = sSentenciaSql + "WHERE CEDULA = @CEDULA";
                SqlConnection conexion = ConexionBD.GetConnection();
                SqlCommand comando = new SqlCommand(sSentenciaSql, conexion);

                comando.Parameters.AddWithValue("@CEDULA", candidato._sCEDULA);
                comando.Parameters.AddWithValue("@ESTADO", candidato._sESTADO);

                comando.ExecuteNonQuery();
                ConexionBD.CloseConnection(conexion);
            }
        }
        #endregion

        #region ReadList
        public static List<Candidato> ReadCandidateList() {
            List<Candidato> listaCandidatos = new List<Candidato>();

            try
            {
                var conn = ConexionBD.GetConnection();
                string sQuery = "SELECT * FROM CANDIDATO";
                SqlCommand command = new SqlCommand(sQuery, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Candidato candidato = new Candidato();
                    candidato._sCEDULA = reader.GetString(0);
                    candidato._sNOMBRE = reader.GetString(1);
                    candidato._sLISTA = reader.GetString(2);
                    candidato._sMAIL = reader.GetString(3);
                    candidato._sESTADO = reader.GetString(4);
                    candidato._dFECHA_CREACION = reader.GetDateTime(5);

                    listaCandidatos.Add(candidato);
                }

                reader.Close();

                ConexionBD.CloseConnection(conn);

                return listaCandidatos;
            }
            catch (SqlTypeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error de: {e.Message}");
            }

            return listaCandidatos;
        }
        #endregion
    }
}

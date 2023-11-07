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
using System.IO.Packaging;
using System.Windows.Forms;

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
        public static void UpdateFile(Candidato candidato)
        {
            //CreateFile(candidato);
            try {
                var conn = ConexionBD.GetConnection();
                string sQuery = "UPDATE CANDIDATO SET NOMBRE = '" + candidato._sNOMBRE + "', LISTA = '" + candidato._sLISTA + "', MAIL = '" + candidato._sMAIL + "', ESTADO = '" + candidato._sESTADO + "' WHERE CEDULA = '" + candidato._sCEDULA + "'";
                SqlCommand command = new SqlCommand(sQuery, conn);
                command.ExecuteNonQuery();

                ConexionBD.CloseConnection(conn);
                MessageBox.Show("Candidato actualizado correctamente");
            } catch (Exception e) {
                MessageBox.Show("Error al actualizar el candidato");
            }
        }
        #endregion

        #region Delete
        public static void DeleteFile(string cedula)
        {
            try
            {
                var conn = ConexionBD.GetConnection();
                string updateSql = "UPDATE CANDIDATO SET ESTADO = 'B' WHERE CEDULA = '" + cedula + "'";

                SqlCommand comandoUpdate = new SqlCommand(updateSql, conn);
                comandoUpdate.ExecuteNonQuery();
                ConexionBD.CloseConnection(conn);
                MessageBox.Show("Candidato eliminado correctamente");
            }
            catch (IOException e)
            {
                Console.WriteLine($"No hay el ");
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

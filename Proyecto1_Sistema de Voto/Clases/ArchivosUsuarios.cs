using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Proyecto1_Sistema_de_Voto.Models;
using Proyecto1_Sistema_de_Voto.clases;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Data;
using System.Windows;

namespace Proyecto1_Sistema_de_Voto.Clases 
{
    public static class ArchivosUsuarios 
    {
        public static Usuario datosUsuarioLogin { get; set; }
        #region Create
        public static void CreateUser (Usuario usuario) 
        {
            try 
            {
                string sSentenciaSql = "INSERT INTO USUARIO (CEDULA, NOMBRES, APELLIDOS, MAIL, CONTRASEÑA, PROVINCIA, ESTADO_VOTO, SEXO, ESTADO)";
                sSentenciaSql = sSentenciaSql + "VALUES (@CEDULA, @NOMBRES, @APELLIDOS, @MAIL, @CONTRASEÑA, @PROVINCIA, @ESTADO_VOTO, @SEXO, @ESTADO)";
                SqlConnection conexion = ConexionBD.GetConnection();
                SqlCommand comando = new SqlCommand(sSentenciaSql, conexion);

                comando.Parameters.AddWithValue("@CEDULA", usuario._sCEDULA);
                comando.Parameters.AddWithValue("@NOMBRES", usuario._sNOMBRES);
                comando.Parameters.AddWithValue("@APELLIDOS", usuario._sAPELLIDOS);
                comando.Parameters.AddWithValue("@MAIL", usuario._sMail);
                comando.Parameters.AddWithValue("@CONTRASEÑA", usuario._sCONTRASEÑA);
                comando.Parameters.AddWithValue("@PROVINCIA", usuario._sPROVINCIA);
                comando.Parameters.AddWithValue("@ESTADO_VOTO", usuario._bESTADO_VOTO);
                comando.Parameters.AddWithValue("@SEXO", usuario._sSEXO);
                comando.Parameters.AddWithValue("@ESTADO", usuario._sESTADO);

                comando.ExecuteNonQuery();
                ConexionBD.CloseConnection(conexion);
            } catch (IOException e) 
            {
                Console.WriteLine($"Error al crear el usuario: {e.Message}");
            }
        }
        #endregion

        #region Read
        public static Usuario ReadUserByCedula (string cedula) 
        {
            Usuario usuario = new Usuario();

            try 
            {
                var conn = ConexionBD.GetConnection();
                string sQuery = "SELECT * FROM USUARIO WHERE CEDULA = '" + cedula + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows[0]["CEDULA"].ToString() == cedula)
                {
                    usuario._sCEDULA = dataSet.Tables[0].Rows[0]["CEDULA"].ToString();
                    usuario._sNOMBRES = dataSet.Tables[0].Rows[0]["NOMBRES"].ToString();
                    usuario._sAPELLIDOS = dataSet.Tables[0].Rows[0]["APELLIDOS"].ToString();
                    usuario._sMail = dataSet.Tables[0].Rows[0]["MAIL"].ToString();
                    usuario._sCONTRASEÑA = dataSet.Tables[0].Rows[0]["CONTRASEÑA"].ToString();
                    usuario._sPROVINCIA = dataSet.Tables[0].Rows[0]["PROVINCIA"].ToString();
                    usuario._bESTADO_VOTO = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ESTADO_VOTO"]);
                    usuario._sSEXO = dataSet.Tables[0].Rows[0]["SEXO"].ToString();
                    usuario._sESTADO = dataSet.Tables[0].Rows[0]["ESTADO"].ToString();
                    usuario._dFECHA_CREACION = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["FECHA_CREACION"]);
                }

                ConexionBD.CloseConnection(conn);

                return usuario;
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

            return usuario;
        }
        #endregion

        #region Update
        public static void UpdateStateVoteUser(Usuario usuario) 
        {
            SqlConnection connection = ConexionBD.GetConnection();
            string sql = "SELECT * FROM USUARIO WHERE CEDULA = '" + usuario._sCEDULA + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows[0]["CEDULA"].ToString() == usuario._sCEDULA)
            {


                string sSentenciaSql = "UPDATE USUARIO ";
                sSentenciaSql = sSentenciaSql + "SET ESTADO_VOTO = @ESTADO_VOTO ";
                sSentenciaSql = sSentenciaSql + "WHERE CEDULA = @CEDULA";
                SqlConnection conexion = ConexionBD.GetConnection();
                SqlCommand comando = new SqlCommand(sSentenciaSql, conexion);

                comando.Parameters.AddWithValue("@CEDULA", usuario._sCEDULA);
                comando.Parameters.AddWithValue("@ESTADO_VOTO", usuario._bESTADO_VOTO);

                comando.ExecuteNonQuery();
                ConexionBD.CloseConnection(conexion);
            }
        }
        #endregion

        #region ReadList
        public static List<Usuario> ReadUsersList () {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try {
                var conn = ConexionBD.GetConnection();
                string sQuery = "SELECT * FROM USUARIO";
                SqlCommand command = new SqlCommand(sQuery, conn);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Usuario user = new Usuario();
                    user._sCEDULA = reader.GetString(0);
                    user._sNOMBRES = reader.GetString(1);
                    user._sAPELLIDOS = reader.GetString(2);
                    user._sMail = reader.GetString(3);
                    user._sCONTRASEÑA = reader.GetString(4);
                    user._sPROVINCIA = reader.GetString(5);
                    user._bESTADO_VOTO = reader.GetBoolean(6);
                    user._sSEXO = reader.GetString(7);
                    user._sESTADO = reader.GetString(8);
                    user._dFECHA_CREACION = reader.GetDateTime(9);

                    listaUsuarios.Add(user);
                }

                reader.Close();

                ConexionBD.CloseConnection(conn);

                return listaUsuarios;
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
                Console.WriteLine($"Error de serialización: {e.Message}");
            }

            return listaUsuarios;
        }
        #endregion
    }
}
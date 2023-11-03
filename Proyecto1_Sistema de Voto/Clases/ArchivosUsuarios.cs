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

namespace Proyecto1_Sistema_de_Voto.Clases 
{
    public static class ArchivosUsuarios 
    {
        public static Usuario datosUsuarioLogin { get; set; }

        private static readonly string directoryPath = "ArchivosUsuarios";

        #region Create
        public static void CreateFile (Usuario usuario) 
        {
            try 
            {
                // Asegurarse de que el directorio exista
                //if (!Directory.Exists(directoryPath)) 
                //{
                //    Directory.CreateDirectory(directoryPath);
                //}

                //string filePath = Path.Combine(directoryPath, usuario._sCedula + ".bin");

                //using (FileStream fs = new FileStream(filePath, FileMode.Create)) 
                //{
                //    IFormatter formatter = new BinaryFormatter();
                //    formatter.Serialize(fs, usuario);
                //}

                //Console.WriteLine("Archivo creado con el Usuario.");
            } catch (IOException e) 
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
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
        public static void UpdateFile (Usuario usuario) 
        {
            CreateFile(usuario);
        }
        #endregion

        #region Delete
        public static void DeleteFile (string cedula) 
        {
            try 
            {
                string filePath = Path.Combine(directoryPath, cedula + ".bin");

                if (File.Exists(filePath)) 
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                } else 
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            } catch (IOException e) 
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
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
                    user._sCONTRASEÑA = reader.GetString(3);
                    user._sPROVINCIA = reader.GetString(4);
                    user._bESTADO_VOTO = reader.GetBoolean(5);
                    user._sSEXO = reader.GetString(6);
                    user._sESTADO = reader.GetString(7);
                    user._dFECHA_CREACION = reader.GetDateTime(8);

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
using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto1_Sistema_de_Voto.clases
{
    public static class ArchivosVotos
    {
        private static readonly string directoryPath = "ArchivosVotos";

        public static int _iContador;

        //public static List<Voto> votos = new List<Voto>();

        #region Create
        public static void CreateFile(Voto voto)
        {
            //Misma lógica que la de crear candidatos y usuarios
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, voto._sID_VOTO.ToString() + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, voto);
                }

                Console.WriteLine("Archivo creado con el Usuario.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        #endregion

        #region Read(GetVotos)
        public static List<Voto> GetVotesList()
        {
            List<Voto> votos = new List<Voto>();

            try
            {
                var conn = ConexionBD.GetConnection();
                string sQuery = "SELECT * FROM VOTO";
                SqlCommand command = new SqlCommand(sQuery, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Voto vote = new Voto();
                    vote._sID_VOTO = reader.GetInt32(0);
                    vote._sCANDIDATO = reader.GetString(1);
                    vote._sESTADO = reader.GetString(2);
                    vote._dFECHA_CREACION = reader.GetDateTime(3);

                    votos.Add(vote);
                }

                reader.Close();

                ConexionBD.CloseConnection(conn);

                return votos;
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

            //Retorna la lista
            return votos;
        }
        #endregion

        //#region Read Sobrecarga
        //public static List<Voto> GetVotos(string candidato)
        //{
        //    List<Voto> votos = new List<Voto>();

        //    try
        //    {
        //        foreach (var archivo in Directory.GetFiles(directoryPath, candidato + ".bin"))
        //        {
        //            using (FileStream fs = new FileStream(archivo, FileMode.Open))
        //            {
        //                BinaryFormatter formatter = new BinaryFormatter();

        //                //Castea el formatter deserializado a un objeto voto
        //                Voto votoDeserializado = (Voto)formatter.Deserialize(fs);

        //                //Guarda el objeto en la lista
        //                votos.Add(votoDeserializado);
        //            }
        //        }
        //    }
        //    catch (SerializationException ex)
        //    {
        //        MessageBox.Show($"Error al deserializar un archivo: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al procesar los archivos: {ex.Message}");
        //    }

        //    //Retorna la lista
        //    return votos;
        //}
        //#endregion

        public static string CalcularPorcentaje(int numeroConvertir, int total)
        {
            double porcentaje = ((double)numeroConvertir / (double)total) * 100;

            int por = (int)Math.Round(porcentaje);

            return $" {por}%";
        }
    }
}

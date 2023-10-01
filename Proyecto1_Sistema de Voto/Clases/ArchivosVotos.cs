using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
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

                string filePath = Path.Combine(directoryPath, voto._sProvincia + ".bin");

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
        public static List<Voto> GetVotos()
        {
            List<Voto> votos = new List<Voto>();

            try
            {
                //Logica parecia a ReadFile de usuarios y candidatos
                //Pero esta vez recorre todo el directorio y obteniene cada archivo

                foreach (var archivo in Directory.GetFiles(directoryPath, "*.bin"))
                {
                    using (FileStream fs = new FileStream(archivo, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        //Castea el formatter deserializado a un objeto voto
                        Voto votoDeserializado = (Voto)formatter.Deserialize(fs);

                        //Guarda el objeto en la lista
                        votos.Add(votoDeserializado);
                    }
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show($"Error al deserializar un archivo: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar los archivos: {ex.Message}");
            }

            //Retorna la lista
            return votos;
        }
        #endregion
    }
}

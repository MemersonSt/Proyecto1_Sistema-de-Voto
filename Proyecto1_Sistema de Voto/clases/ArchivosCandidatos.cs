using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.clases
{
    public static class ArchivosCandidatos
    {
        private static readonly string directoryPath = "ArchivosCandidatos";

        #region Create
        public static void CreateFile(Candidato candidato)
        {
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, candidato._sCedula + ".bin");//Aqui se crea el archivo con el nombre de la cedula del candidato

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, candidato);
                }

                Console.WriteLine("Archivo creado con el Usuario.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        #endregion

        #region Read
        public static Candidato ReadFile(string cedula)
        {
            Candidato candidato = null;

            try
            {
                string filePath = Path.Combine(directoryPath, cedula + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    candidato = (Candidato)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }

            return candidato;
        }
        #endregion

        #region Update
        public static void UpdateFile(Candidato candidato)
        {
            CreateFile(candidato);
        }
        #endregion

        #region Delete
        public static void DeleteFile(string cedula)
        {
            try
            {
                string filePath = Path.Combine(directoryPath, cedula + ".bin");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }
        #endregion

        #region ReadList
        public static List<Candidato> ReadList () {
            List<Candidato> listaCandidatos = new List<Candidato>();

            try {
                string [] filePaths = Directory.GetFiles(directoryPath);

                foreach (string filePath in filePaths) {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                        IFormatter formatter = new BinaryFormatter();
                        listaCandidatos.Add((Candidato)formatter.Deserialize(fs));
                    }
                }
            } catch (IOException e) {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            } catch (SerializationException e) {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }

            return listaCandidatos;
        }
        #endregion
    }
}

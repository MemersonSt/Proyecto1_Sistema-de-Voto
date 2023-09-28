using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Proyecto1_Sistema_de_Voto.Models;

namespace Proyecto1_Sistema_de_Voto.Clases {
    public static class ArchivosUsuarios {
        private static readonly string directoryPath = "ArchivosUsuarios";

        #region Create
        public static void CreateFile (Usuario usuario) {
            try {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPath)) {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, usuario._sCedula + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, usuario);
                }

                Console.WriteLine("Archivo creado con el Usuario.");
            } catch (IOException e) {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        #endregion

        #region Read
        public static Usuario ReadFile (string cedula) {
            Usuario usuario = null;

            try {
                string filePath = Path.Combine(directoryPath, cedula + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                    IFormatter formatter = new BinaryFormatter();
                    usuario = (Usuario)formatter.Deserialize(fs);
                }
            } catch (FileNotFoundException) {
                Console.WriteLine("El archivo no existe.");
            } catch (IOException e) {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            } catch (SerializationException e) {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }

            return usuario;
        }
        #endregion

        #region Update
        public static void UpdateFile (Usuario usuario) {
            CreateFile(usuario);
        }
        #endregion

        #region Delete
        public static void DeleteFile (string cedula) {
            try {
                string filePath = Path.Combine(directoryPath, cedula + ".bin");

                if (File.Exists(filePath)) {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                } else {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            } catch (IOException e) {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }
        #endregion
    }
}
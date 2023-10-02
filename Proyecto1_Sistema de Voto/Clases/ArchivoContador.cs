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
    public static class ArchivoContador
    {
        private static readonly string directoryPath = "ArchivoContador";

        public static int _iContador = 0;

        //public static List<Voto> votos = new List<Voto>();

        #region Create
        public static void CreateFile(Contador cont)
        {
            //Misma lógica que la de crear candidatos y usuarios
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath,"Contador.bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, cont);
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
        public static Contador ReadFile()
        {
            Contador cont = null;

            try
            {
                string filePath = Path.Combine(directoryPath,"Contador.bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    cont = (Contador)formatter.Deserialize(fs);
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

            return cont;
        }
        #endregion
    }
}

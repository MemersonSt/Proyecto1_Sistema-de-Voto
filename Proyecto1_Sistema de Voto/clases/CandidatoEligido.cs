using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.clases {
    public static class CandidatoEligido {
        private static readonly string directoryPath = "CandidatoEligido";
        static List<Candidato> listaCandidatos = ArchivosCandidatos.ReadList();
        static string nombreCandidato = "NombreDelCandidato"; // Nombre del candidato que deseas contar
        static string nombreArchivo = $"{nombreCandidato}.txt";
        #region Create
        public static void CreateFile (Votos votos) {
            try {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPath)) {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, votos.nombreCandidato + ".bin");//Aqui se crea el archivo con el nombre de la cedula del candidato

                using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, nombreCandidato);
                }
                Console.WriteLine("Archivo creado.");
            } catch (IOException e) {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        #endregion

        #region Read
        public static Votos ReadFile (string nombreCandidato) {
            Votos votos = null;

            try {
                string filePath = Path.Combine(directoryPath, nombreCandidato + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                    IFormatter formatter = new BinaryFormatter();
                    votos = (Votos)formatter.Deserialize(fs);
                }
            } catch (FileNotFoundException) {
                Console.WriteLine("El archivo no existe.");
            }

            return votos;
        }
        #endregion

        #region ReadList
        public static void ReadList () {
            List<Votos> listaVotos = new List<Votos>();

        }
        #endregion
    }
}

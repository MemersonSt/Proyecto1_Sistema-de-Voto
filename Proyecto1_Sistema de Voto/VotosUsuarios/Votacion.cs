//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proyecto1_Sistema_de_Voto.VotosUsuarios {
//    public static class Votacion {
//        private static readonly string directoryPath = "ArchivosCandidatos";
//        private static string nombreCandidato;

//        private static string archivoVotos;

//        public static void votacion (string nombreCandidato) {
//            // El nombre del archivo de votos puede basarse en el nombre del candidato o algún identificador único
//            archivoVotos = $"{nombreCandidato}.txt";
//        }

//        public static void RegistrarVoto (string usuario) {
//            // Registra el voto en el archivo de texto
//            File.AppendAllText(archivoVotos, $"{usuario} votó el {DateTime.Now}{Environment.NewLine}");
//        }
//    }
//}

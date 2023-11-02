using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.clases
{
    public static class ConexionBD
    {
        public static string sDbName = "SistemaVoto_DB";
        public static string sServerName = "DESKTOP-7FRKFBE\\SQLEXPRESS";
        public static string sUser = "sa";
        public static string sPassword = "Tecsu.2023";

        public static string sStringConnection = "Persist Security Info=False;User ID="+sUser+";Password="+sPassword+";Initial Catalog="+sDbName+";Server="+sServerName+"";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(sStringConnection);
            conn.Open();
            return conn;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }
    }
}

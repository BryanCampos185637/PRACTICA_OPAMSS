using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Persistencia
{
    public class DbCommun
    {
        public static SqlConnection Conectar()
        {
            try
            {
                var ConexionBD = "data source=DESKTOP-TUVI7D5\\SPARTANDEV;initial catalog=PracticaOpamss;user=sa;password=triz7+10;";
                var conexion = new SqlConnection(ConexionBD);
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();
                return conexion;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

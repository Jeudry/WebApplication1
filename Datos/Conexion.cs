using System.Data.SqlClient;

namespace WebApplication1.Datos
{
    public class Conexion
    {
        private string CadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        internal static object Open()
        {
            throw new NotImplementedException();
        }

        public string getCadenaSQL()
        {
            return CadenaSQL;
        }
    }
}

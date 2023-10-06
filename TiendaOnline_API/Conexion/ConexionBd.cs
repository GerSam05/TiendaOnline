using Bodega_API.Conexion;

namespace Bodega_API.Conexion
{
    public class ConexionBd
    {
        private readonly string connectionString = string.Empty;

        public ConexionBd()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:Conexion").Value;
        }
        public string CadenaSQL()
        {
            return connectionString;
        }
    }
}

namespace ApiRestTienda.Conexion
{
    public class ConexionBD
    {
        private string connectionString = string.Empty;
        public ConexionBD()
        {
            var contructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = contructor.GetSection("ConnectionStrings:conexionmaestra").Value;
        }

        public string ConnectionString()
        {
            return connectionString;
        }
    }
}

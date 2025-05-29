using System.Data.SqlClient;
namespace crudcore.Datos
{
    public class Conexion
    {
        private string CadenaSQL = "";
        public Conexion() 
        { 
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetConnectionString("CadenaSQL");
        }
        public string getCadenaSQL()
        {
            return CadenaSQL;
        }

    }
}

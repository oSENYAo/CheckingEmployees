using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CheckingEmployees.Data.ADO.NET
{
    public class AppDbContext
    {
        private readonly IConfiguration configuration;
        public string ConnectString { get; set; }
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Connection()
        {
            var sql = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            ConnectString = this.configuration.GetConnectionString("DefaultConnection");
        }
    }
}

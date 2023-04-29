using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CorporateQnA.Infrastructure.DbContext
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        private readonly IDbConnection _connection;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("LocalDBConnection");
            this._connection = new SqlConnection(_connectionString);
        }

        public IDbConnection GetConnection()
        {
            return this._connection;
        }
    }
}

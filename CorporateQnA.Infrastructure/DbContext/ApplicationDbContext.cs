using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this._connectionString = this._configuration.GetConnectionString("TeamLDBConnection");
            this._connection = new SqlConnection(_connectionString);
        }

        public IDbConnection GetConnection()
        {
            return this._connection;
        }
    }
}

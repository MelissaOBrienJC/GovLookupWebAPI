using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

using Microsoft.Data.SqlClient;
using GovLookup.Business;
using GovLookup.Controllers;
using Microsoft.Extensions.Logging;

namespace GovLookup.DataAccess
{
    public class GovLookupDBContext: DbContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

              

        
        public GovLookupDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("GovLookupDB");
            
        }


        public async Task<IEnumerable<TCustomEntity>> ExecStoredProcedure<TCustomEntity>(string storedProcedureName, IDictionary<string, object> parameters) where TCustomEntity : class
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                  
                    var resultSet = connection.Query<TCustomEntity>(storedProcedureName, parameters, commandTimeout: 240,
                        commandType: CommandType.StoredProcedure);
                    return resultSet;
                }
            }
            catch
            {
                return null;
            }

        }


    }
}

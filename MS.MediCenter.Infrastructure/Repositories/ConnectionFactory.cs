using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace MS.MediCenter.Infrastructure.Repositories
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnectionMS
        {
            get { return GetConnection("DefaultConnection"); }
        }

        private IDbConnection GetConnection(string connectionString)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var cn = factory.CreateConnection();

            if (cn == null) return null;

            cn.ConnectionString = _configuration.GetConnectionString(connectionString);
            cn.Open();
            return cn;
        }
    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using MS.MediCenter.Application.Interfaces.Security;
using MS.MediCenter.Core.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace MS.MediCenter.Infrastructure.Repositories.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public UserRepository(IConfiguration configuration)
        {
            _connectionFactory = new ConnectionFactory(configuration);
        }

        public async Task<int> AddAsync(User entity)
        {
            var sql = "SP_I_USUARIO";
            using(var cn = _connectionFactory.GetConnectionMS)
            {
                var param = new DynamicParameters();
                param.Add("@Nombre", entity.Nombre, DbType.String);
                param.Add("@Contrasenia", entity.Contrasenia, DbType.String);
                param.Add("@Estado", entity.Estado, DbType.Boolean);
                param.Add("@IdPerfil", entity.Perfil, DbType.Int32);
                param.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await cn.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

                return param.Get<int>("@Id");
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "SP_S_USER_ID";
            using (var cn = _connectionFactory.GetConnectionMS)
            {
                var result = await cn.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

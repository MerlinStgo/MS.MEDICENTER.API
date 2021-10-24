using Dapper;
using Microsoft.Extensions.Configuration;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Core.Security;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MS.MediCenter.Infrastructure.Repositories.Security
{
    public class UserRepository<T> : IRepositoryAsync<User>
    {
        private readonly ConnectionFactory _connectionFactory;
        public UserRepository(IConfiguration configuration)
        {
            _connectionFactory = new ConnectionFactory(configuration);
        }

        public async Task<User> AddAsync(User entity)
        {
            var sql = "SP_I_USUARIO";
            using (var cn = _connectionFactory.GetConnectionMS)
            {
                var param = new DynamicParameters();
                param.Add("@Nombre", entity.Nombre, DbType.String);
                param.Add("@Contrasenia", entity.Contrasenia, DbType.String);
                param.Add("@Estado", entity.Estado, DbType.Boolean);
                param.Add("@IdPerfil", entity.Perfil, DbType.Int32);
                param.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await cn.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

                entity.Id = param.Get<int>("@Id");

                return entity;
            }
        }

        public Task<User> DeleteAsync(int id)
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

        public Task<User> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

    }
}

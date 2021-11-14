using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MS.MediCenter.Application.DTOs;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Specifications;
using MS.MediCenter.Application.Wrappers;
using MS.MediCenter.Core.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MS.MediCenter.Application.Features.Security.Queries
{
    public class GetAllUserQuery : IRequest<PagedResponse<List<UserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }

        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, PagedResponse<List<UserDto>>>
        {
            private readonly IRepositoryAsync<User> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly IDistributedCache _distributedCache;
            public GetAllUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _distributedCache = distributedCache;
            }


            public async Task<PagedResponse<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {

                var cacheKey = $"listadoUsuarios_{request.PageSize}_{request.PageNumber}_{request.Nombre}_{request.Usuario}";
                string serializedListadoUsuarios;
                var listadoClientes = new List<User>();
                var redisListadoClientes = await _distributedCache.GetAsync(cacheKey);

                if(redisListadoClientes != null)
                {
                    serializedListadoUsuarios = Encoding.UTF8.GetString(redisListadoClientes);
                    listadoClientes = JsonConvert.DeserializeObject<List<User>>(serializedListadoUsuarios);
                }
                else
                {
                    //listadoClientes = await _repositoryAsync.GetAllAsync(new PagedUserSpecification(request.PageSize, request.PageNumber, request.Nombre));
                    serializedListadoUsuarios = JsonConvert.SerializeObject(listadoClientes);
                    redisListadoClientes = Encoding.UTF8.GetBytes(serializedListadoUsuarios);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distributedCache.SetAsync(cacheKey, redisListadoClientes, options);
                }
                var usuarioDto = _mapper.Map<List<UserDto>>(listadoClientes);
                //return new PagedResponse<List<UserDto>>(usuarioDto, request.PageNumber, request.PageSize);
                return null;
            }
        }
    }
}

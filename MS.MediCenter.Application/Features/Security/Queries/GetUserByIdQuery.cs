using AutoMapper;
using MediatR;
using MS.MediCenter.Application.DTOs;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Wrappers;
using MS.MediCenter.Core.Security;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MS.MediCenter.Application.Features.Security.Queries
{
    public class GetUserByIdQuery : IRequest<Response<UserDto>>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserDto>>
        {
            private readonly IRepositoryAsync<User> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetUserByIdQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _repositoryAsync.GetByIdAsync(request.Id);

                if(user == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }

                var dto = _mapper.Map<UserDto>(user);
                return new Response<UserDto>(dto);
            }
        }
    }
}

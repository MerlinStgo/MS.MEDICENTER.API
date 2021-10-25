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
    public class GetAllUserQuery :IRequest<PagedResponse<List<UserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }

        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, PagedResponse<List<UserDto>>>
        {
            private readonly IRepositoryAsync<User> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            
            public Task<PagedResponse<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var usuario = _repositoryAsync
            }
        }
    }
}

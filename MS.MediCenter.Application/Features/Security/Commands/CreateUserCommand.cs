using AutoMapper;
using MediatR;
using MS.MediCenter.Application.Interfaces;
using MS.MediCenter.Application.Wrappers;
using MS.MediCenter.Core.Security;
using System.Threading;
using System.Threading.Tasks;
namespace MS.MediCenter.Application.Features.Security.Commands
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }
        public int Perfil { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<User>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}

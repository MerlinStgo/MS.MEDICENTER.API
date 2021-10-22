using MediatR;
using MS.MediCenter.Application.Wrappers;
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
        public Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

using AutoMapper;
using MS.MediCenter.Application.Features.Security.Commands;
using MS.MediCenter.Core.Security;

namespace MS.MediCenter.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateUserCommand, User>();
            #endregion
        }
    }
}

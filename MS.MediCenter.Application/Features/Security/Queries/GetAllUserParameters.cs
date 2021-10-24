using MS.MediCenter.Application.Parameters;

namespace MS.MediCenter.Application.Features.Security.Queries
{
    public class GetAllUserParameters : RequestParameter
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }
}

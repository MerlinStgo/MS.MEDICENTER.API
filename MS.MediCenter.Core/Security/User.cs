using MS.MediCenter.Core.Common;

namespace MS.MediCenter.Core.Security
{
    public class User : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }
        public int Perfil { get; set; }

    }
}

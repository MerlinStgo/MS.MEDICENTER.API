namespace MS.MediCenter.Core.Security
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }
        public int Perfil { get; set; }
    }
}

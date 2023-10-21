namespace Tickest.Models.Entidades.Usuarios
{
    public class UsuarioRegra
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public ICollection<UsuarioRegraMapeamento> usuarioRegras { get; set; }
    }
}

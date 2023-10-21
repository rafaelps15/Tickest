using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.Entidades.Usuarios
{
    public class UsuarioRegraMapeamento
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario usuario { get; set; }

        public int UsuarioRegraId { get; set; }

        public UsuarioRegra UsuarioRegra { get; set; }
    }
}

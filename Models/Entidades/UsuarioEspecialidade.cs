using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class UsuarioEspecialidade
    {
        [Key]
        public int Id { get; set; }

        public Usuario Analista { get; set; }
        public int AnalistaId { get; set; }

        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
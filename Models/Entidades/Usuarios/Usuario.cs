using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.Entidades.Usuarios
{
    public abstract class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Senha { get; set; }
    }
}

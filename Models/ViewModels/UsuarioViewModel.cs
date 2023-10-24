using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmacaoSenha { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.Entidades.Usuarios
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public ICollection<TicketMensagem> TicketMensagens { get; set; }

        public ICollection<UsuarioRegraMapeamento> UsuarioRegraMapeamento { get; set; }

        public ICollection<Ticket> AberturaTickets { get; set; }

        public ICollection<Ticket> TicketResponsaveis { get; set; }
        public ICollection<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }

        public ICollection<Ticket> Solicitacoes { get; set; }

    }
}

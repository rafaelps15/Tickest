using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.Entidades
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
        [StringLength(250)]
        public string Senha { get; set; }

        //public int CargoId { get; set; }
        //public virtual Cargo Cargo { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public ICollection<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }

        public ICollection<Ticket> TicketsSolicitados { get; set; }

        public ICollection<Ticket> TicketsAnalista { get; set; }

        public ICollection<Ticket> TicketsDestinatarios { get; set; }
    }
}

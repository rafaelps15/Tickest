using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class TicketRequest
    {
        /* Usuário que irá solicitar uma abertura de Ticket */
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(500)]
        public byte[] Anexo { get; set; }

        public TicketPrioridadeEnum Prioridade{ get; set; }

        public int SolicitanteId { get; set; }
        public Usuario Solicitante { get; set; }

        ////public int DepartamentoId { get; set; }
        //public Departamento Departamento { get; set; }

    }
}

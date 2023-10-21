using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        public DateTime DataLimite { get; set; }
        [Required]
        [StringLength(500)]

        public string Descricao { get; set; }
        public byte[] Anexo { get; set; }
        public TicketPrioridadeEnum Prioridade { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public int SolicitanteId { get; set; }
        public Usuario Solicitante { get; set; }
        public int? AnalistaId { get; set; }
        public Usuario Analista { get; set; }
        public int AbertoPorId { get; set; }
        public Usuario AbertoPor { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        //Maria mandou: Tive esse problema x
        //Joao mandou: Resolvido, teste por favor
        //Maria mandou: Funcionou
        public ICollection<TicketMensagem> Mensagens { get; set; }
    }
}

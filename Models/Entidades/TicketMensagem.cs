using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class TicketMensagem
    {
        public int Id { get; set; }

        public DateTime DataMensagem { get; set; }

        public string Mensagem { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}

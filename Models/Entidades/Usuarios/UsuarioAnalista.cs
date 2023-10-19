namespace Tickest.Models.Entidades.Usuarios
{
    public class UsuarioAnalista : Usuario
    {
        //public Departamento Departamento { get; set; }
        //public int DepartamentoId { get; set; }

        public ICollection<Ticket> AberturaTickets { get; set; }

        public ICollection<Ticket> TicketResponsaveis { get; set; }

        public ICollection<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }
    }
}

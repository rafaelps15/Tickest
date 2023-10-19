namespace Tickest.Models.Entidades.Usuarios
{
    public class UsuarioSolicitante : Usuario
    {
        public ICollection<Ticket> Solicitacoes { get; set; }
    }
}

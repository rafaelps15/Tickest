using Microsoft.EntityFrameworkCore;
using Tickest.Models.Entidades;
using Tickest.Models.ViewModels;

namespace Tickest.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEspecialidade>()
                .HasOne(ue => ue.Usuario)
                .WithMany(u => u.UsuarioEspecialidades)
                .HasForeignKey(ue => ue.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurar relacionamento entre Usuario e TicketsSolicitados
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.TicketsSolicitados)
                .WithOne(t => t.Solicitante)
                .HasForeignKey(t => t.SolicitanteId);

            // Configurar relacionamento entre Usuario e TicketsAnalista
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.TicketsAnalista)
                .WithOne(t => t.Analista)
                .HasForeignKey(t => t.AnalistaId);

            // Configurar relacionamento entre Usuario e TicketsDestinatario
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.TicketsDestinatarios)
                .WithOne(t => t.Destinatario)
                .HasForeignKey(t => t.DestinatarioId);

            // Configurar relacionamento entre Ticket e Solicitante
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Solicitante)
                .WithMany(u => u.TicketsSolicitados)
                .HasForeignKey(t => t.SolicitanteId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurar relacionamento entre Ticket e Analista
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Analista)
                .WithMany(u => u.TicketsAnalista)
                .HasForeignKey(t => t.AnalistaId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurar relacionamento entre Ticket e Destinatario
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Destinatario)
                .WithMany(u => u.TicketsDestinatarios)
                .HasForeignKey(t => t.DestinatarioId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Notificacoes> Notificacoes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFase> TicketFases { get; set; }
        public DbSet<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }
    }
}

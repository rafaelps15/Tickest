using Microsoft.EntityFrameworkCore;
using Tickest.Models.Entidades;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioEspecialidade>()
                .HasOne(ue => ue.Analista)
                .WithMany(u => u.UsuarioEspecialidades)
                .HasForeignKey(ue => ue.AnalistaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.AberturaTickets)
                .WithOne(t => t.AbertoPor)
                .HasForeignKey(t => t.AbertoPorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.TicketResponsaveis)
                .WithOne(t => t.Analista)
                .HasForeignKey(t => t.AnalistaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.UsuarioEspecialidades)
                .WithOne(ue => ue.Analista)
                .HasForeignKey(ue => ue.AnalistaId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Solicitacoes)
                .WithOne(t => t.Solicitante)
                .HasForeignKey(t => t.SolicitanteId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.TicketMensagens)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasMany(u => u.Mensagens)
                .WithOne(t => t.Ticket)
                .HasForeignKey(t => t.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Usuario> Solicitantes { get; set; }
        public DbSet<Usuario> Analistas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Notificacoes> Notificacoes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }
        public DbSet<UsuarioRegra> UsuarioRegras { get; set; }
        public DbSet<UsuarioRegraMapeamento> UsuarioRegraMapeamentos { get; set; }
    }
}

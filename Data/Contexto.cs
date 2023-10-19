using Microsoft.EntityFrameworkCore;
using Tickest.Models.Entidades;
using Tickest.Models.Entidades.Usuarios;
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
                .HasOne(ue => ue.Analista)
                .WithMany(u => u.UsuarioEspecialidades)
                .HasForeignKey(ue => ue.AnalistaId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<UsuarioAnalista>()
            //    .HasOne(u => u.Departamento)
            //    .WithMany()
            //    .HasForeignKey(u => u.DepartamentoId)
            //    .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<UsuarioAnalista>()
            //    .HasOne(u => u.Departamento)
            //    .WithMany()
            //    .HasForeignKey(u => u.DepartamentoId);

            modelBuilder.Entity<UsuarioAnalista>()
                .HasMany(u => u.AberturaTickets)
                .WithOne(t => t.AbertoPor)
                .HasForeignKey(t => t.AbertoPorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsuarioAnalista>()
                .HasMany(u => u.TicketResponsaveis)
                .WithOne(t => t.Analista)
                .HasForeignKey(t => t.AnalistaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsuarioAnalista>()
                .HasMany(u => u.UsuarioEspecialidades)
                .WithOne(ue => ue.Analista)
                .HasForeignKey(ue => ue.AnalistaId);

            modelBuilder.Entity<UsuarioSolicitante>()
                .HasMany(u => u.Solicitacoes)
                .WithOne(t => t.Solicitante)
                .HasForeignKey(t => t.SolicitanteId);
             
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioAnalista> Solicitantes { get; set; }
        public DbSet<UsuarioSolicitante> Analistas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Notificacoes> Notificacoes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFase> TicketFases { get; set; }
        public DbSet<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }
    }
}

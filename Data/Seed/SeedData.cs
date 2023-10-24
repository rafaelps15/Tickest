using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.Regras;

namespace Tickest.Data.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            CadastrarRegrasDefault(serviceProvider);
            CadastrarAdmin(serviceProvider);

        }

        private static void CadastrarRegrasDefault(IServiceProvider serviceProvider)
        {
            var opt = serviceProvider.GetRequiredService<DbContextOptions<Contexto>>();
            using (var context = new Contexto(opt))
            {
                var regras = UsuarioRegraDefault.ObterRegras();
                var regrasDB = context.UsuarioRegras.ToList();

                var regrasSalvar = regras.Where(p => !regrasDB.Select(x => x.Nome).Contains(p));

                if (regrasSalvar != null && regrasSalvar.Any())
                    context.Set<UsuarioRegra>().AddRange(regrasSalvar.Select(p => new UsuarioRegra
                    {
                        Nome = p,
                    }));

                context.SaveChanges();
            }
        }

        private static void CadastrarAdmin(IServiceProvider serviceProvider)
        {
            var opt = serviceProvider.GetRequiredService<DbContextOptions<Contexto>>();
            using (var context = new Contexto(opt))
            {
                var emailAdmin = "rafaelps15@hotmail.com";
                var regraAdmin = context.UsuarioRegras.FirstOrDefault(p => p.Nome == UsuarioRegraDefault.Administrador);

                var existeEsseAdmin = context.Usuarios.Any(p => p.Email == emailAdmin);
                if(!existeEsseAdmin)
                {
                    context.Set<Usuario>().Add(new Usuario
                    {
                        Email = emailAdmin,
                        Senha = "123",
                        DataCadastro = DateTime.Now,
                        Nome = "Rafael",
                        UsuarioRegraMapeamento = new List<UsuarioRegraMapeamento> 
                        {
                            new UsuarioRegraMapeamento
                            {
                                UsuarioRegraId = regraAdmin.Id
                            }
                        }
                    });
                }

                context.SaveChanges();
            }
        }
    }
}

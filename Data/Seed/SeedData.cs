using Microsoft.EntityFrameworkCore;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.Regras;

namespace Tickest.Data.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
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
    }
}

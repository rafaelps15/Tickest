using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tickest.Data;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.Resultados;

namespace Tickest.Controllers
{
    public class BaseController : Controller
    {
        protected readonly Contexto _context;
        private IHttpContextAccessor _httpContextAccessor;

        public BaseController(Contexto context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResultado> SignIn(string email, string senha)
        {
            var resultado = new LoginResultado();

            if (string.IsNullOrEmpty(email))
                resultado.AddErro("Email é obrigatório");

            if (string.IsNullOrEmpty(senha))
                resultado.AddErro("Senha é obrigatório");

            var usuario = _context.Set<Usuario>()
                .Include(p => p.UsuarioRegraMapeamento).ThenInclude(p => p.UsuarioRegra)
                .FirstOrDefault(p => p.Email == email);

            if (usuario == null || usuario.Senha != senha)
                resultado.AddErro("Usuário ou senha inválida");

            if (!resultado.Sucesso)
                return resultado;

            var regras = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usuario.Email, ClaimValueTypes.String, "tickest")
            };

            foreach (var regra in usuario.UsuarioRegraMapeamento)
                regras.Add(new Claim(ClaimTypes.Role, regra.UsuarioRegra.Nome));

            var userIdentity = new ClaimsIdentity(regras, "Authentication");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow
            };

            await _httpContextAccessor.HttpContext.SignInAsync("Authentication", userPrincipal, authProperties);

            return resultado;
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync("Authentication");
        }

        public async Task<Usuario> ObterUsuarioLogado()
        {
            var autenticadoResultado = await _httpContextAccessor.HttpContext.AuthenticateAsync("Authentication");
            if (!autenticadoResultado.Succeeded)
                return null;

            var email = autenticadoResultado.Principal.FindFirst(claim => claim.Type == ClaimTypes.Email).Value;

            return _context.Set<Usuario>().FirstOrDefault(p => p.Email == email);
        }
    }
}

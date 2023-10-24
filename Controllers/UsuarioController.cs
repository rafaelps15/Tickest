using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tickest.Data;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.ViewModels;

namespace Tickest.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(Contexto context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            //Aguardando a tela
            var viewModel = new UsuarioViewModel(); 
            return View(viewModel); // Retorne a View de cadastro com o ViewModel
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] UsuarioViewModel request)
        {
            bool usuarioExistente = _context.Set<Usuario>().Any(u => u.Email == request.Email);

            if (usuarioExistente)
            {
                ModelState.AddModelError(nameof(UsuarioViewModel.Email), "Já existe um usuário com o mesmo Email.");
                return View(request);
            }

            var novoUsuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                DataCadastro = DateTime.Now
            };

            _context.Set<Usuario>().Add(novoUsuario);
            _context.SaveChanges();

            return RedirectToAction("Login", "Autenticacao"); 
        }
    }
}

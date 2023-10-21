using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] UsuarioViewModel viewModel)
        {
            bool usuarioExistente = _context.Set<Usuario>().Any(u => u.Email == viewModel.Email);

            if (usuarioExistente)
            {
                ModelState.AddModelError(nameof(UsuarioViewModel.Email), "Já existe um usuário com o mesmo Email.");
                return View(viewModel);
            }

            //var novoUsuario = new Usuario
            //{
            //    Nome = viewModel.Nome,
            //    Email = viewModel.Email,
            //    Senha = viewModel.Senha
            //};

            //_context.Set<Usuario>().Add(novoUsuario);
            //_context.SaveChanges();

            //Redirecionar para a próxima página.
            return RedirectToAction("");
        }

        [HttpGet]
        [HttpGet]
        public IActionResult CadastradoSucesso()
        {
            // Página de sucesso após o cadastro
            return View();
        }
    }
}

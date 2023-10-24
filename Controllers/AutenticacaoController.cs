using Microsoft.AspNetCore.Mvc;
using Tickest.Data;
using Tickest.Models.ViewModels;

namespace Tickest.Controllers
{
    public class AutenticacaoController : BaseController
    {
        public AutenticacaoController(Contexto context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        #region Login

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel { RedirectToUrl = returnUrl };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var loginResult = await SignIn(request.Email, request.Senha);

            if (!loginResult.Sucesso)
            {
                ViewBag.ErrorMessage = string.Join(Environment.NewLine, loginResult.Erros);
                return View(request);
            }

            if (!string.IsNullOrEmpty(request.RedirectToUrl))
                return Redirect(request.RedirectToUrl);

            return RedirectToAction("Listagem", "Ticket");
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}

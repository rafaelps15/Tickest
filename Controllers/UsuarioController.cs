using Microsoft.AspNetCore.Mvc;
using Tickest.Data;
using Tickest.Models.ViewModels;


namespace Tickest.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto db;
        public UsuarioController(Contexto db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessarCadastro([FromForm] UsuarioViewModel viewModel)
        {
            // Aqui você pode processar os dados do formulário
            if (ModelState.IsValid)
            {
                // O modelo é válido, você pode prosseguir com o processamento
                // por exemplo, salvar os dados no banco de dados
                // e redirecionar para outra página
                return RedirectToAction("Sucesso");
            }
            else
            {
                // O modelo não é válido, retorne a mesma página com erros
                return View("Cadastrar", viewModel);
            }
        }

        [HttpGet]
        public IActionResult Sucesso()
        {
            // Página de sucesso após o cadastro
            return View();
        }
    }
}

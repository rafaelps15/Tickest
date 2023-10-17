using Microsoft.AspNetCore.Mvc;
using Tickest.Data;
using Tickest.Models.Entidades;
using Tickest.Models.ViewModels;

namespace Tickest.Controllers
{
    public class TicketController : Controller
    {
        private readonly Contexto db;

        public TicketController(Contexto db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            //CARREGAR A TELA

            //var viewModel = new TicketViewModel
            //{
            //    Departamentos = db.Set<Departamento>().Select(departamento => new DepartamentoViewModel
            //    {
            //        Id = departamento.Id,
            //        Nome = departamento.Nome
            //    }).ToArray()
            //};

            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Nome = "Administração" });
            list.Add(new Departamento { Id = 2, Nome = "Hel-Desk" });
            list.Add(new Departamento { Id = 3, Nome = "NOC" });
            list.Add(new Departamento { Id = 4, Nome = "Financeiro" });
            list.Add(new Departamento { Id = 5, Nome = "Almoxerifado" });
            list.Add(new Departamento { Id = 6, Nome = "Infraestrutura" });


            return View(list);
        }

        [HttpPost]
        public IActionResult Cadastrar(TicketViewModel viewModel)
        {
            //CLICA BOTA DO FORM

            if (!ModelState.IsValid)
                return View();

            return View();
        }
    }
}

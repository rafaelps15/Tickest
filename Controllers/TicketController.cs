using Microsoft.AspNetCore.Mvc;
using Tickest.Data;
using Tickest.Extensions;
using Tickest.Models.Entidades;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.ViewModels;

namespace Tickest.Controllers
{
    public class TicketController : Controller
    {
        private readonly Contexto _context;

        public TicketController(Contexto context)
        {
            this._context = context;
        }

        #region SEED

        private void Seed()
        {
            var solicitante = new UsuarioSolicitante()
            {
                Nome = "Maria",
                Email = "maria@gmail.com",
                Senha = "123",
            };

            var departamento = new Departamento
            {
                Nome = "TI",
                //Analistas = analistas
            };


            var sistemas = new Especialidade
            {
                Departamento = departamento,
                Nome = "Sistemas"
            };

            var infra = new Especialidade
            {
                Departamento = departamento,
                Nome = "Infra"
            };

            var analistas = new List<UsuarioAnalista>()
            {
                new UsuarioAnalista
                {
                    Nome = "Gabriel",
                    Email = "gabriel@gmail.com",
                    Senha = "123",
                    UsuarioEspecialidades = new List<UsuarioEspecialidade>
                    {
                        new UsuarioEspecialidade
                        {
                            Especialidade = sistemas
                        }
                    }
                },

                new UsuarioAnalista
                {
                    Nome = "Rafael",
                    Email = "rafaell@gmail.com",
                    Senha = "123",
                    UsuarioEspecialidades = new List<UsuarioEspecialidade>
                    {
                        new UsuarioEspecialidade
                        {
                            Especialidade = sistemas
                        },
                        new UsuarioEspecialidade
                        {
                            Especialidade = infra
                        }
                    }
                }
            };

            _context.Add(solicitante);
            _context.Add(departamento);
            _context.Add(sistemas);
            _context.Add(infra);
            _context.AddRange(analistas);

            _context.SaveChanges();
        }

        #endregion

        [HttpGet]
        public IActionResult Form(int? id)
        {
            //CARREGAR A TELA

            var model = new TicketViewModel
            {
                //DataMinima = DateTime.Today.AddDays(2),
                DataLimite = DateTime.Today.AddDays(5),

                TicketPrioridades = Enum.GetValues(typeof(TicketPrioridadeEnum))
                    .Cast<TicketPrioridadeEnum>()
                    .Select(e => new TicketPrioridadeViewModel
                    {
                        Descricao = e.GetDescription(),
                        Valor = e,
                        Nome = e.ToString()
                    }),

                Departamentos = _context.Set<Departamento>().Select(departamento => new DepartamentoViewModel
                {
                    Id = departamento.Id,
                    Nome = departamento.Nome
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Form(TicketViewModel request)
        {
            // ENVIA DADOS TELA

            //Validacao Data**
            var hoje = DateTime.Today;

            //if (request.DataMinima < hoje || request.DataMinima > hoje.AddDays(2))
            //    ModelState.AddModelError(nameof(TicketViewModel.DataMinima), "A data limite não pode pode ser menor do que hoje e maior do que dois dias.");

            if (request.DataLimite < hoje || request.DataLimite > hoje.AddDays(5))
                ModelState.AddModelError(nameof(TicketViewModel.DataLimite), "A data limite não pode pode ser menor do que hoje e maior do que cinco dias.");

            var solicitante = _context.Set<UsuarioSolicitante>().FirstOrDefault(p => p.Email == request.Solicitante);
            if (solicitante == null)
                ModelState.AddModelError(nameof(TicketViewModel.Solicitante), "Solicitante não encontrado");

            if (!ModelState.IsValid)
                return View(request);

            // SE PASSOU DESSE IF QUER DIZER QUE ESTÁ VÁLIDO

            //CRIAR ENTIDADE A PARTIR DOS DADOS PREENCHIDOS NA VIEWMODEL
            var entidade = new Ticket();
            entidade.Titulo = request.Titulo;
            entidade.DataLimite = request.DataLimite;
            entidade.DepartamentoId = request.DepartamentoSelectionado;
            entidade.Anexo = request.Anexo;
            entidade.Descricao = request.Descricao;
            entidade.TicketStatus = TicketStatus.Aberto;
            entidade.SolicitanteId = solicitante.Id;
            entidade.Comentario = string.Empty;
            entidade.DataCriacao = DateTime.Now;
            entidade.AbertoPorId = 4; //USUARIO LOGADO


            //Salvar no banco
            _context.Set<Ticket>().Add(entidade);

            _context.SaveChanges();

            return View(request);
        }
    }
}

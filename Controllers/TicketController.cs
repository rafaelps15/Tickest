using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickest.Data;
using Tickest.Extensions;
using Tickest.Models.Entidades;
using Tickest.Models.Entidades.Usuarios;
using Tickest.Models.Regras;
using Tickest.Models.ViewModels;

namespace Tickest.Controllers
{
    //AUTHORIZE = USUÁRIO AUTENTICADO (APENAS USUÁRIOS AUTENTICADOS)
    [Authorize]
    public class TicketController : BaseController
    {
        public TicketController(Contexto context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        #region SEED

        private void Seed()
        {
            var colaboradorRegra = _context.Set<UsuarioRegra>().FirstOrDefault(p => p.Nome == UsuarioRegraDefault.Colaborador);
            var analistaRegra = _context.Set<UsuarioRegra>().FirstOrDefault(p => p.Nome == UsuarioRegraDefault.Analista);
            var administradorRegra = _context.Set<UsuarioRegra>().FirstOrDefault(p => p.Nome == UsuarioRegraDefault.Administrador);

            var colaborador = new Usuario()
            {
                Nome = "Maria",
                Email = "maria@gmail.com",
                Senha = "123",
                UsuarioRegraMapeamento = new List<UsuarioRegraMapeamento>()
                {
                    new UsuarioRegraMapeamento
                    {
                        UsuarioRegra = colaboradorRegra
                    } 
                }
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

            var analistas = new List<Usuario>()
            {
                new Usuario
                {
                    Nome = "Gabriel",
                    Email = "gabriel@gmail.com",
                    Senha = "123",
                    UsuarioRegraMapeamento = new List<UsuarioRegraMapeamento>()
                    {
                        new UsuarioRegraMapeamento
                        {
                            UsuarioRegra = analistaRegra
                        }
                    },
                    UsuarioEspecialidades = new List<UsuarioEspecialidade>
                    {
                        new UsuarioEspecialidade
                        {
                            Especialidade = sistemas
                        }
                    }
                },

                new Usuario
                {
                    Nome = "Rafael",
                    Email = "rafaell@gmail.com",
                    Senha = "123",
                     UsuarioRegraMapeamento = new List<UsuarioRegraMapeamento>()
                     {
                         new UsuarioRegraMapeamento
                         {
                             UsuarioRegra = analistaRegra
                         },
                         new UsuarioRegraMapeamento
                         {
                             UsuarioRegra = administradorRegra
                         }
                     },
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

            _context.Add(colaborador);
            _context.Add(departamento);
            _context.Add(sistemas);
            _context.Add(infra);
            _context.AddRange(analistas);

            _context.SaveChanges();
        }

        #endregion

        #region Cadastrar

        [HttpGet]
        [Authorize(Roles = "administrador")] //USUÁRIO AUTENTICADO E TEM A ROLE ADMINISTRADO
        public IActionResult Cadastrar(int? id)
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
        [Authorize(Roles = "administrador")] //USUÁRIO AUTENTICADO E TEM A ROLE ADMINISTRADO
        public async Task<IActionResult> Cadastrar(TicketViewModel request)
        {
            // ENVIA DADOS TELA

            //Validacao Data**
            var hoje = DateTime.Today;

            //if (request.DataMinima < hoje || request.DataMinima > hoje.AddDays(2))
            //    ModelState.AddModelError(nameof(TicketViewModel.DataMinima), "A data limite não pode pode ser menor do que hoje e maior do que dois dias.");

            if (request.DataLimite < hoje || request.DataLimite > hoje.AddDays(5))
                ModelState.AddModelError(nameof(TicketViewModel.DataLimite), "A data limite não pode pode ser menor do que hoje e maior do que cinco dias.");

            var solicitante = _context.Set<Usuario>().FirstOrDefault(p => p.Email == request.Solicitante);
            if (solicitante == null)
                ModelState.AddModelError(nameof(TicketViewModel.Solicitante), "Solicitante não encontrado");

            if (!ModelState.IsValid)
                return View(request);
            byte[] arquivo = null;
            if (request.Anexo != null && request.Anexo.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    request.Anexo.CopyTo(stream);
                    arquivo = stream.ToArray();
                }
            }

            // SE PASSOU DESSE IF QUER DIZER QUE ESTÁ VÁLIDO

            //CRIAR ENTIDADE A PARTIR DOS DADOS PREENCHIDOS NA VIEWMODEL
            var entidade = new Ticket();
            entidade.Titulo = request.Titulo;
            entidade.DataLimite = request.DataLimite;
            entidade.Prioridade = request.TicketPrioridadeSelecionado.Value;
            entidade.DepartamentoId = request.DepartamentoSelectionado;
            entidade.Anexo = arquivo;
            entidade.Descricao = request.Descricao;
            entidade.TicketStatus = TicketStatus.Aberto;
            entidade.SolicitanteId = solicitante.Id;
            entidade.DataCriacao = DateTime.Now;
            entidade.AbertoPorId = (await ObterUsuarioLogado()).Id;


            //Salvar no banco
            _context.Set<Ticket>().Add(entidade);

            _context.SaveChanges();

            return RedirectToAction("Listagem");
        }

        #endregion

        [HttpGet]
        public IActionResult Listagem()
        {
            //Verificar quais tickets estão abertos e apresentar na tela
            List<TicketViewModel> viewModels = _context.Set<Ticket>()
                .Where(p => p.TicketStatus == TicketStatus.Aberto)
                .Select(p => new TicketViewModel
                {
                    //Adicionar o que for necessário para apresentar o Ticket
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    DataLimite = p.DataLimite,
                    DepartamentoSelectionado = p.DepartamentoId,

                }).ToList();

            return View(viewModels);
        }
    }
}

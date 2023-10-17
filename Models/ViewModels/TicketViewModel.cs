using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades;

namespace Tickest.Models.ViewModels
{
    public class TicketViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public TicketPrioridadeEnum TicketPrioridade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public ICollection<DepartamentoViewModel> Departamentos { get; set; }
    }
}

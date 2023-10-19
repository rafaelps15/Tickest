using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades;

namespace Tickest.Models.ViewModels
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            //Não deveria estar na Model Ticket ????? 
            TicketPrioridades = new List<TicketPrioridadeViewModel>();
            Departamentos = new List<DepartamentoViewModel>();
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataMinima { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
        //public string Comentario { get; set; }
        public byte[] Anexo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Solicitante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public TicketPrioridadeEnum? TicketPrioridadeSelecionado { get; set; }

        [Required(ErrorMessage = "Selecione um departamento")]
        public int DepartamentoSelectionado { get; set; }

        #region DropDowns

        public IEnumerable<TicketPrioridadeViewModel> TicketPrioridades { get; set; }
        public IEnumerable<DepartamentoViewModel> Departamentos { get; set; }

        #endregion
    }
}

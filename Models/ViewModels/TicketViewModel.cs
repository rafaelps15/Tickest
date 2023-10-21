using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades;

namespace Tickest.Models.ViewModels
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            TicketPrioridades = new List<TicketPrioridadeViewModel>();
            Departamentos = new List<DepartamentoViewModel>();
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório.")]
        public string Titulo { get; set; }

        //[Required(ErrorMessage = "O campo 'Data Mínima' é obrigatório.")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DataMinima { get; set; }

        [Required(ErrorMessage = "O campo 'Data Limite' é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
        public string Descricao { get; set; }
        //public string Comentario { get; set; }
        public IFormFile Anexo { get; set; }

        [Required(ErrorMessage = "O campo 'Solicitante' é obrigatório.")]
        public string Solicitante { get; set; }

        [Required(ErrorMessage = "Selecione uma prioridade.")]
        public TicketPrioridadeEnum? TicketPrioridadeSelecionado { get; set; }

        [Required(ErrorMessage = "Selecione um departamento")]
        public int DepartamentoSelectionado { get; set; }

        #region DropDowns

        public IEnumerable<TicketPrioridadeViewModel> TicketPrioridades { get; set; }
        public IEnumerable<DepartamentoViewModel> Departamentos { get; set; }

        #endregion
    }
}

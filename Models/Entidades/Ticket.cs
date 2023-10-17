using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tickest.Models.Entidades
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Título { get; set; }

        [Required]
        public DateTime DataCriação { get; set; }
        public DateTime DataLimite { get; set; }

        [Required]
        [StringLength(500)]
        public string Descrição { get; set; }
        [Required]
        [StringLength(500)]
        public string Comentario { get; set; }
        public string Anexo { get; set; }

        public TicketPrioridadeEnum Prioridade { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public int SolicitanteId { get; set; }
        public Usuario Solicitante { get; set; }

        public int AnalistaId { get; set; }
        public Usuario Analista { get; set; }

        public int DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; }


        /* Criei uma classe tipo Enum -> Mostrar para o Cristo
        public enum Prioridade
        {
            Baixa = 0, Média = 1, Alta = 2, Urgente = 3
        }

        public enum Status
        {
            Análise = 0, Andamento = 1, Teste = 2, Concluído = 3, Cancelado = 4 
        }
        */

    }
}

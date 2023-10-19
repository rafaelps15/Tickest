using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }
        public DateTime DataLimite { get; set; }
        //public DateTime DataMinima { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(500)]
        public string Comentario { get; set; }
        public byte[] Anexo { get; set; }
        public TicketPrioridadeEnum Prioridade { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public int SolicitanteId { get; set; }
        public UsuarioSolicitante Solicitante { get; set; }

        public int? AnalistaId { get; set; }
        public UsuarioAnalista Analista { get; set; }

        public int AbertoPorId { get; set; }
        public UsuarioAnalista AbertoPor { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

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

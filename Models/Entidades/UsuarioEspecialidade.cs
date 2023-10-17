using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickest.Models.Entidades
{
    public class UsuarioEspecialidade
    {
        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Especialidade Especialidade { get; set; }

        public int EspecialidadeId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickest.Models.Entidades
{
    public class Especialidade
    {
        public int Id { get; set; }

        public string Area { get; set; }

        public Departamento Departamento { get; set; }

        public int DepartamentoId { get; set; }

        public ICollection<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }


    }
}
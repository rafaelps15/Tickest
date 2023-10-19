using System.ComponentModel.DataAnnotations;
using Tickest.Models.Entidades.Usuarios;

namespace Tickest.Models.Entidades
{
    public class Departamento
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Nome { get; set; }

        //public ICollection<Area> Areas { get; set; }
        public ICollection<UsuarioAnalista> Analistas { get; set; }
        public ICollection<Especialidade> Especialidades { get; set; }

        /*  Não entendi
       [Required]
       public bool Gerenciador { get; set; }*/
    }
}

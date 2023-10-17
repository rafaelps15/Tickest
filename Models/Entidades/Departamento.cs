using System.ComponentModel.DataAnnotations;

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
        public ICollection<Usuario> Usuarios { get; set; }

        /*  Não entendi
       [Required]
       public bool Gerenciador { get; set; }*/
    }
}

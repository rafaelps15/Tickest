namespace Tickest.Models.Entidades
{
    public class Especialidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public ICollection<UsuarioEspecialidade> UsuarioEspecialidades { get; set; }
    }
}
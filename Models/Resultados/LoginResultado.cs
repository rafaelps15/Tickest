namespace Tickest.Models.Resultados
{
    public class LoginResultado
    {
        public LoginResultado()
        {
            Erros = new List<string>();
        }

        public ICollection<string> Erros { get; set; }

        public bool Sucesso => !Erros.Any();

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}

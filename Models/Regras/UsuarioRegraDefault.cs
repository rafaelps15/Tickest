namespace Tickest.Models.Regras
{
    public static class UsuarioRegraDefault
    {
        public static string Analista = "analista";
        public static string Colaborador = "colaborador";
        public static string Administrador = "administrador";
        public static string Suporte = "suporte";
        public static string Cliente = "cliente";

        public static IEnumerable<string> ObterRegras()
        {
            yield return Analista;
            yield return Colaborador;
            yield return Administrador;
            yield return Suporte;
            yield return Cliente;
        }
    }
}

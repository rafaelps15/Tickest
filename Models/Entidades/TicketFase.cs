using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickest.Models.Entidades
{
    public class TicketFase
    {
        //Verificar com o Christo ->Exemplo; Atividades, Em Andamento, Correção e etc...
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }
    }
}
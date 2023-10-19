using System.ComponentModel;

namespace Tickest.Models.Entidades
{
    public enum TicketPrioridadeEnum
    {
        [Description("Baixa")]
        Baixa = 1,

        [Description("Normal")]
        Normal = 2,

        [Description("Urgente")]
        Urgente = 3
    }
}
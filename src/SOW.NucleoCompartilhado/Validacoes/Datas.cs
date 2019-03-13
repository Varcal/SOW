using System;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {

        public static DomainNotification MaiorQue(DateTime dataEsperada, DateTime dataAtual, string mensagem)
        {
            return dataAtual < dataEsperada ? new DomainNotification("GarantirQueDataMaiorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(DateTime dataEsperada, DateTime dataAtual, string mensagem)
        {
            return dataAtual > dataEsperada ? new DomainNotification("GarantirQueDataMenorQue", mensagem) : null;
        }

        public static DomainNotification SaoIgual(DateTime dataEsperada, DateTime dataAtual, string mensagem)
        {
            return dataAtual != dataEsperada ? new DomainNotification("GarantirQueDataIgual", mensagem) : null;
        }

        public static DomainNotification Difente(DateTime dataEsperada, DateTime dataAtual, string mensagem)
        {
            return dataAtual == dataEsperada ? new DomainNotification("GarantirQueDataIgual", mensagem) : null;
        }


        public static DomainNotification DataValida(DateTime data, string mensagem)
        {
            return data == DateTime.MinValue ? new DomainNotification("GarantirQueDataEstaValida", mensagem) : null;
        }
    }
}

using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {
        public static DomainNotification MenorQue(float valorEsperado, float valorAtual, string mensagem)
        {
           return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(double valorEsperado, double valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(decimal valorEsperado, decimal valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(float valorEsperado, float valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(double valorEsperado, double valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(decimal valorEsperado, decimal valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(float valorEsperado, float valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(double valorEsperado, double valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(decimal valorEsperado, decimal valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(float valorEsperado, float valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(double valorEsperado, double valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(decimal valorEsperado, decimal valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }
    }
}

using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {
        public static DomainNotification SaoIguais(byte valorEsperado, byte valorAtual, string mensagem)
        {
            return valorAtual != valorEsperado ? new DomainNotification("GarantirQueSaoIguais", mensagem) : null;
        }

        public static DomainNotification SaoIguais(short valorEsperado, short valorAtual, string mensagem)
        {
            return valorAtual != valorEsperado ? new DomainNotification("GarantirQueSaoIguais", mensagem) : null;
        }

        public static DomainNotification SaoIguais(int valorEsperado, int valorAtual, string mensagem)
        {
            return valorAtual != valorEsperado ? new DomainNotification("GarantirQueSaoIguais", mensagem) : null;
        }

        public static DomainNotification SaoIguais(long valorEsperado, long valorAtual, string mensagem)
        {
            return valorAtual != valorEsperado ? new DomainNotification("GarantirQueSaoIguais", mensagem) : null;
        }

        public static DomainNotification MenorQue(byte valorEsperado, byte valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMenorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(short valorEsperado, short valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMenorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(int valorEsperado, int valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMenorQue", mensagem) : null;
        }

        public static DomainNotification MenorQue(long valorEsperado, long valorAtual, string mensagem)
        {
            return valorAtual >= valorEsperado ? new DomainNotification("GarantirQueMenorQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(byte valorEsperado, byte valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMenorIgualQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(short valorEsperado, short valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMenorIgualQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(int valorEsperado, int valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMenorIgualQue", mensagem) : null;
        }

        public static DomainNotification MenorIgualQue(long valorEsperado, long valorAtual, string mensagem)
        {
            return valorAtual > valorEsperado ? new DomainNotification("GarantirQueMenorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(byte valorEsperado, byte valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(short valorEsperado, short valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(int valorEsperado, int valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorQue(long valorEsperado, long valorAtual, string mensagem)
        {
            return valorAtual <= valorEsperado ? new DomainNotification("GarantirQueMaiorQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(byte valorEsperado, byte valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(short valorEsperado, short valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(int valorEsperado, int valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification MaiorIgualQue(long valorEsperado, long valorAtual, string mensagem)
        {
            return valorAtual < valorEsperado ? new DomainNotification("GarantirQueMaiorIgualQue", mensagem) : null;
        }

        public static DomainNotification EstaEntre(byte menorValor, byte maiorValor, byte valorAtual, string mensagem)
        {
            return valorAtual < menorValor && valorAtual > maiorValor ? new DomainNotification("GarantirQueEstaEntre", mensagem) : null;
        }

        public static DomainNotification EstaEntre(short menorValor, short maiorValor, short valorAtual, string mensagem)
        {
            return valorAtual < menorValor && valorAtual > maiorValor ? new DomainNotification("GarantirQueEstaEntre", mensagem) : null;
        }

        public static DomainNotification EstaEntre(int menorValor, int maiorValor, int valorAtual, string mensagem)
        {
            return valorAtual < menorValor && valorAtual > maiorValor ? new DomainNotification("GarantirQueEstaEntre", mensagem) : null;
        }

        public static DomainNotification EstaEntre(long menorValor, long maiorValor, long valorAtual, string mensagem)
        {
            return valorAtual < menorValor && valorAtual > maiorValor ? new DomainNotification("GarantirQueEstaEntre", mensagem) : null;
        }
    }
}

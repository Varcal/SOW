using System.Text.RegularExpressions;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {
        public static DomainNotification NaoEstaVazioOuNulo(string texto, string mensagem)
        {
            return string.IsNullOrWhiteSpace(texto) ? new DomainNotification("GarantirQueNaoEhVazioOuNulo", mensagem) : null;
        }

        public static DomainNotification TamanhoEntre(string texto, int min, int max, string mensagem)
        {
            return texto.Length > max || texto.Length < min ? new DomainNotification("GarantirTamanhoEntre", mensagem) : null;
        }

        public static DomainNotification Tamanho(string texto, int tamanho, string mensagem)
        {
            return texto.Length != tamanho ? new DomainNotification("GarantirQueTamanho", mensagem) : null;
        }

        public static DomainNotification TamanhoMaximo(string texto, int tamanho, string mensagem)
        {
            return texto.Length > tamanho ? new DomainNotification("GarantirQueTamanhoMaximo", mensagem) : null;
        }

        public static DomainNotification SaoIguais(string valorEsperado, string valorAtual, string mensagem)
        {
            return valorAtual != valorEsperado ? new DomainNotification("GarantirQueSaoIguais", mensagem) : null;
        }

        public static DomainNotification SomenteNumeros(string texto, string mensagem)
        {
            var regex = new Regex(@"^[0-9]+$");

            return (!regex.IsMatch(texto)) ? new DomainNotification("GarantirQueSomenteNumeros", mensagem) : null;
        }
    }
}

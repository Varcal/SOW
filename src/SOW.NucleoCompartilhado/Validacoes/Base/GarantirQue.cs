using System.Collections.Generic;
using System.Linq;
using SOW.NucleoCompartilhado.DomainEvents.Core;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes.Base
{
    public class GarantirQue
    {
        public static bool EstaValido(params DomainNotification[] notificacoes)
        {
            var notificacoesNaoNulas = notificacoes.Where(validation => validation != null);
            var notificacoesDominio = notificacoesNaoNulas as IList<DomainNotification> ?? notificacoesNaoNulas.ToList();
            NotificarTodos(notificacoesDominio);

            return notificacoesDominio.Count().Equals(0);
        }

        private static void NotificarTodos(IEnumerable<DomainNotification> notificaoes)
        {
            notificaoes.ToList().ForEach(DomainEvent.RaiseEvent);
        }
    }
}

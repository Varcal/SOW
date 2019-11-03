using System;
using SOW.NucleoCompartilhado.DomainEvents.Core;

namespace SOW.NucleoCompartilhado.DomainEvents.Notifications
{
    public class DomainNotification: Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        public static void CriarNotificacao(string v1, string v2)
        {
            RaiseEvent(new DomainNotification(v1, v2));
        }
    }
}

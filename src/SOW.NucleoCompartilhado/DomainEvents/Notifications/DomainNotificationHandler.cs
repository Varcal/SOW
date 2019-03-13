using System.Collections.Generic;
using System.Linq;

namespace SOW.NucleoCompartilhado.DomainEvents.Notifications
{
    public class DomainNotificationHandler: IDomainNotificationHandler
    {
        private IList<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public void Dispose()
        {
            _notifications = null;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }
    }
}

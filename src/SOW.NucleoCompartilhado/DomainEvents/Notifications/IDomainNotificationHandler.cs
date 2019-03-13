using System.Collections.Generic;
using SOW.NucleoCompartilhado.DomainEvents.Interfaces;

namespace SOW.NucleoCompartilhado.DomainEvents.Notifications
{
    public interface IDomainNotificationHandler: IHandler<DomainNotification>
    {
        bool HasNotification();
        IEnumerable<DomainNotification> GetNotifications();
    }
}

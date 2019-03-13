using System;
using SOW.NucleoCompartilhado.DomainEvents.Core;

namespace SOW.NucleoCompartilhado.DomainEvents.Interfaces
{
    public interface IHandler<in T>: IDisposable where T: Event
    {
        void Handle(T @event);
    }
}

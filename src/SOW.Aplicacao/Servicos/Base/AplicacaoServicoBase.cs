﻿using SOW.NucleoCompartilhado.DomainEvents.Core;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Aplicacao.Servicos.Base
{
    public abstract class AplicacaoServicoBase
    {
        private readonly IDomainNotificationHandler _notifications;
        private readonly IUnitOfWork _uow;

        protected AplicacaoServicoBase(IUnitOfWork uow)
        {
            _notifications = (IDomainNotificationHandler)DomainEvent.ServiceProvider.GetService(typeof(IDomainNotificationHandler));
            _uow = uow;
        }

        protected void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        protected void Rollback()
        {
            _uow.Rollback();
        }

        protected bool Save()
        {
            return !_notifications.HasNotification() && _uow.Save();
        }
    }
}

using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<bool> EnviarComando<T>(T comando) where T : Command;


        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}

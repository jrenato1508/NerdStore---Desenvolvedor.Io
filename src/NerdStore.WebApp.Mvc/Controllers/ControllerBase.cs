using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("330daf4d-8b9d-4a74-935c-94cee29128a5");
        
        
        //private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        //protected ControllerBase(IMediatorHandler mediatorHandler)
        //{
            
        //    _mediatorHandler = mediatorHandler;
        //}



    }
        
}

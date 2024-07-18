using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    public class DomaninEvent : Event
    {
        public DomaninEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}

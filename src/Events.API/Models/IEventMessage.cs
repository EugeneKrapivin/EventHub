using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API.Models
{
    public interface IEventMessage
    {
        Guid Id { get; }
        Guid OriginId { get; }
    }
}

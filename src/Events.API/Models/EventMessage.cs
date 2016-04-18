using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API.Models
{
    public class EventMessage : IEventMessage
    {
        public Guid Id { get; set; }
        public Guid OriginId { get; set; }
    }
}

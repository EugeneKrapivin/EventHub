using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.API.Models;
using MassTransit;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.API.Controllers
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private IBusControl _bus;

        public EventsController(ILogger<EventsController> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
            bus.Start();
        }

        [HttpPost]
        public async Task Post([FromBody]EventMessage ev)
        {
            _logger.LogDebug($"Got event {ev.Id}:{ev.OriginId}");

            await _bus.Publish(ev);

            _logger.LogDebug($"Message queued");
        }

    }
}

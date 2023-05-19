using MassTransit;
using MessageContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransitGrpcClientTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public TestController(IPublishEndpoint publishEndpoint, ILogger<TestController> logger)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public string Get(string name)
        {
            _publishEndpoint.Publish<Message>(new Message { Text = name });

            return name;
        }
    }
}

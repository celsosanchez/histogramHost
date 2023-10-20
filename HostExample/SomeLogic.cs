using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostExample
{
    internal class SomeLogic
    {
        private ILogger<SomeLogic> _logger;


        public SomeLogic()
        {
            //_logger = Program.App.Services.GetRequiredService<Logger>();
        }
        public SomeLogic(ILogger<SomeLogic> logger)
        {
            _logger = logger;

        }
        public void TellTheTime()
        {
            var aService = Program.App.Services.GetRequiredService<AService>();
            var logger = Program.App.Services.GetRequiredService<ILogger<SomeLogic>>();
            aService.LoggingSomething();
            logger.LogInformation($"{DateTime.Now}");   
            //_logger.LogTrace($"{DateTime.Now}");
        }
    }
}

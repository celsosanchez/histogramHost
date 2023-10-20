using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostExample
{
    public class AService
    {
        private ILogger<AService> _logger;

        public AService(ILogger<AService> logger) {
            _logger = logger;
        }
        public void LoggingSomething() {

            _logger.LogCritical("sabpidubirudabadpirubadbad");
        }
    }
}

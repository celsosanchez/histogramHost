using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HostExample
{
    public class AServiceConsumer
    {
        private ILogger<AService> _logger;
        private AService _aservice;

        public AServiceConsumer(ILogger<AService> logger, AService aService)
        {
            _logger = logger;
            _aservice = aService;
            _logger.LogInformation("Consumer service started");
            _aservice.LoggingSomething();

            ShowUI();
        }

        private void ShowUI()
        {
            Thread thread = new Thread(LaunchUI);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void LaunchUI()
        {
            var window = new Graphic();
            var dispatcher = Dispatcher.CurrentDispatcher;

            dispatcher.BeginInvoke(window.StartParty);
            dispatcher.Invoke(window.ShowDialog);
        }
    }
}

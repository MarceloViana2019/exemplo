using ExemploArquitetura.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExemploArquitetura.Commands.Results
{
    public class MonitorCommandResult : ICommandResult
    {
        public IEnumerable<CustomerCommandResult> Customers { get; set; }
        public IEnumerable<ProviderCommandResult> Providers { get; set; }
        public IEnumerable<ServiceCommandResult> Services { get; set; }

        public MonitorCommandResult()
        {
            Customers = new List<CustomerCommandResult>();
            Providers = new List<ProviderCommandResult>();
            Services = new List<ServiceCommandResult>();
        }
    }
}
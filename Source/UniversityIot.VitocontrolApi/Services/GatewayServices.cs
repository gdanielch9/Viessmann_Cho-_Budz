using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityIot.VitocontrolApi.Repositories;

namespace UniversityIot.VitocontrolApi.Services
{
    public class GatewayServices
    {
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayServices(IGatewayRepository gatewayRepository)
        {
            _gatewayRepository = gatewayRepository;
        }

        public bool RegisterGateway(int serialNumber)
        {
            return true;
        }
    }
}
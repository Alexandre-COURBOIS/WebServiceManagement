using System;
using System.Threading.Tasks;
using WebServiceManagement.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using WebServiceMangement.Client;
using WebServiceManagement.Utils;
using WebServiceManagement.Core.Mapper;
using WebServiceManagement.Client.Mapper;
using System.Collections.Generic;
using WebServiceManagement.Core.Entity;

namespace WebServiceManagement.Test.Client
{

    [TestClass]
    public class ClientRequestorTest
    {

        private static IRequestor _clientRequestor;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IRequestor, WsRequestor>();
            services.AddScoped<IAgencyEntityMapper, ClientAgencyEntityMapper>();
            services.AddScoped<IHttpRequestFactory, HttpRequestFactory>();
            services.AddHttpClient<RequestGenerator>();
            var serviceProvider = services.BuildServiceProvider();
            _clientRequestor = serviceProvider.GetService<IRequestor>();
        }

        [TestMethod]
        public async Task TestGetAgencies()
        {
            List<AgencyEntity> agencyEntities = await _clientRequestor.getAgencies();
            
            Assert.IsNotNull(agencyEntities);
        }
        
        [TestMethod]
        public async Task TestGetAgency()
        {
            Random random = new Random();
            
            AgencyEntity agency = await _clientRequestor.getAgency(random.Next(1, 21));
            
            Assert.IsNotNull(agency);
        }
        
        
    }
}

using WebServiceManagement.Client.Entity;
using WebServiceManagement.Client.Mapper;
using WebServiceManagement.Core.Entity;
using WebServiceManagement.Core.Mapper;
using WebServiceManagement.Requestor;

namespace WebServiceMangement.Client
{
    public class WsRequestor : Requestor
    {
        protected RequestGenerator _generator;
        protected IAgencyEntityMapper _mapper;
        protected HttpClient _httpClient;

        public WsRequestor(RequestGenerator requestGenerator, HttpClient client, IAgencyEntityMapper clientAgencyEntityMapper) 
        {
            _generator = requestGenerator;
            _mapper = clientAgencyEntityMapper;
            _httpClient = client; 
        }

        public override async Task<List<AgencyEntity>> getAgencies()
        {
            var responseMessage =  await _httpClient.SendAsync(_generator.generateRequestToGetAgencies());
            var content = await responseMessage.Content.ReadAsStringAsync();

            List<AgencyEntity> AgencyList = _mapper.MapList(content);

            return AgencyList;
        }

    }
}

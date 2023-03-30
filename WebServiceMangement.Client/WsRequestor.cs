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
            HttpResponseMessage responseMessage =  await _httpClient.SendAsync(_generator.GenerateRequestToGetAgencies());
            String content = await responseMessage.Content.ReadAsStringAsync();

            return _mapper.MapList(content);
        }

        public override async Task<AgencyEntity> getAgency(int agencyId)
        {
            HttpResponseMessage responseMessage =  await _httpClient.SendAsync(_generator.GenerateRequestToGetAgency(agencyId));

            String content = await responseMessage.Content.ReadAsStringAsync();
            
            return _mapper.Map(content);
        }
    }
}

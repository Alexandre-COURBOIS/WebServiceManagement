using WebServiceManagement.Core.Interfaces;

namespace WebServiceMangement.Client
{
    public class RequestGenerator
    {
        public const string URI_DRIVE_REQUEST = "http://88.168.248.140:8000";

        IHttpRequestFactory _httpRequestFactory;
        HttpClient _httpClient;

        public RequestGenerator(IHttpRequestFactory httpRequestFactory, HttpClient httpClient)
        {
            _httpRequestFactory = httpRequestFactory;
            _httpClient = httpClient;
        }

        public HttpRequestMessage GenerateRequestToGetAgencies()
        {
            return _httpRequestFactory.RequesterDefault(HttpMethod.Get, URI_DRIVE_REQUEST + "/agencies", null);
        }
        
        public HttpRequestMessage GenerateRequestToGetAgency(int agencyId)
        {
            return _httpRequestFactory.RequesterDefault(HttpMethod.Get, URI_DRIVE_REQUEST + "/agency/" + agencyId, null);
        }
    }
}

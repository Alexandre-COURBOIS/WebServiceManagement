using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceManagement.Core.Interfaces
{
    public interface IHttpRequestFactory
    {
        public HttpRequestMessage RequesterDefault(HttpMethod method, string uri, HttpContent? content = null);
    }
}

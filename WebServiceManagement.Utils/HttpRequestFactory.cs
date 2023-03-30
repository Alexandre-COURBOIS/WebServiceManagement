using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServiceManagement.Core.Interfaces;

namespace WebServiceManagement.Utils
{
    public class HttpRequestFactory : IHttpRequestFactory
    {
        HttpRequestMessage IHttpRequestFactory.RequesterDefault(HttpMethod method, string uri, HttpContent content)
        {
            return new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(uri),
                Content = content
            };
        }
    }
}

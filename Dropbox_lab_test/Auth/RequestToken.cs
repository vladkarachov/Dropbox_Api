using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox_lab_test.Auth
{
    class RequestToken
    {
        private static HttpRequestMessage _request;
        private static Uri BaseServiceUri { get; set; }

        public RequestToken()
        {
            _request = new HttpRequestMessage();
            //я не знаю как по-человечески ето сделать
            BaseServiceUri = new Uri("https://api.dropbox.com/oauth2/token");
            Uri($"?code={ConfigurationHelper.code}&grant_type=authorization_code");
            WithAuth();
            Method(new HttpMethod("POST"));
            
        }

        public RequestToken WithAuth()
        {
            var authToken = Encoding.ASCII.GetBytes($"{ConfigurationHelper.app_key}:{ConfigurationHelper.app_sec}");
            _request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
            return this;
        }
       
        public RequestToken Uri(string url)
        {
            _request.RequestUri = BaseServiceUri.Append(url);
            return this;
        }

        public RequestToken Method(HttpMethod method)
        {
            _request.Method = method;
            return this;
        }

        public ApiResponse Execute()
        {
            using (var httpClient = new HttpClient())
            {
                _request.Headers.Referrer = _request.RequestUri;
                var response = httpClient.SendAsync(_request, CancellationToken.None).Result;
                return new ApiResponse(response);
            }
        }
    }
}

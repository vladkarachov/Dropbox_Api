using Newtonsoft.Json;
using System.Net.Http;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Builders;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox_lab_test.Api
{
    class DropboxApiLab: DropboxApiContent //наследуем целую 1 переменную и переделываем конструктор. ООП, конечно, серьезное
    {
        public DropboxApiLab()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }
        public ApiResponse DeleteFile(string path)
        {
            var Body = new Base();
            Body.Path = path;
            var requestBody = JsonConvert.SerializeObject(Body);
            var url = "files/delete_v2";
            return request.Uri(url).Method(HttpMethod.Post)
                .WithBody(requestBody)
                 .Execute();
        }
        public ApiResponse GetFileMeta(string path)
        {
            var Body = new Base();
            Body.Path = path;
            var requestBody = JsonConvert.SerializeObject(Body);
            var url = "files/get_metadata";
            return request.Uri(url).Method(HttpMethod.Post)
                .WithBody(requestBody)
                 .Execute();
        }

       
    }
}

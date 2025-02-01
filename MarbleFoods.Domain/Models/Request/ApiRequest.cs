using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models.Request
{
    public class ApiRequest
    {
        public ApiRequest()
        {
            Headers = new Dictionary<string, string>();
        }
        public string Url { get; set; }
        public dynamic Data { get; set; }

        public ApiType ApiType { get; set; } = ApiType.GET;
        public string AccessToken { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}

using MarbleFoods.Domain.Enums;
using MarbleFoods.Domain.Models.Request;
using MarbleFoods.Domain.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MarbleFoods.Infrastructure.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public IHttpClientFactory _httpClient { get; set; }
        private readonly ILogger<HttpRequestService> _logger;
        private readonly IConfiguration _configuration;

        public HttpRequestService(IHttpClientFactory httpClient, ILogger<HttpRequestService> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                if (apiRequest.Url.StartsWith("https"))
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                }

                var client = new HttpClient(httpClientHandler);
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }
                foreach (var header in apiRequest.Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                message.Method = apiRequest.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.GET => HttpMethod.Get,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };

                _logger.LogInformation("Api Request: {@apiRequest}", apiRequest);
                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    _logger.LogInformation("Api Response: {@apiResponse}", json);

                    var apiResponseDto = JsonConvert.DeserializeObject<T>(json);
                    return apiResponseDto;
                }
                else
                {
                    apiRequest.AccessToken = string.Empty;
                    apiRequest.Headers = new Dictionary<string, string>();
                    var json = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation("Api Error: {@apiError}, Api Error Content: {@apiErrorContent}", response, json);
                    var dto = new ApiResponse<List<string>>
                    {
                        IsSuccessful = false,
                        Message = $"Error: {response.StatusCode}",
                        Data = new List<string> { response?.ReasonPhrase },
                    };
                    var res = JsonConvert.SerializeObject(dto);
                    var apiResponseDto = JsonConvert.DeserializeObject<T>(json);
                    return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Api Exception: {@apiException}", ex);
                var dto = new ApiResponse<List<string>>
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    Data = new List<string> { Convert.ToString(ex) },
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}

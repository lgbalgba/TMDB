using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TMDB.Api
{
    /// <summary>
    /// Representa a requisicao da API TMDB.
    /// </summary>
    public class ApiRequest
    {
        #region Local Variables

        private readonly IRepositorySettings _settings;

        #endregion

        #region Constructors

        public ApiRequest(IRepositorySettings settings)
        {
            _settings = settings;
        }

        #endregion

        #region Public Methods

        public async Task<ApiResponse<T>> SearchAsync<T>(string command, int pageNumber, IDictionary<string, string> parameters)
        {           
            using (HttpClient client = CreateClient())
            {
                pageNumber = pageNumber < 1 ? 1 : pageNumber;

                if (!parameters.Keys.Contains("page", StringComparer.OrdinalIgnoreCase))
                    parameters.Add("page", (pageNumber < 1 ? 1 : pageNumber).ToString());

                string cmd = CreateCommand(command, parameters);

                HttpResponseMessage response = await client.GetAsync(cmd).ConfigureAwait(false);

                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    return new ApiResponse<T>();

                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return result;
            }
        }

        public async Task<T> FindAsync<T>(string command, int pageNumber, IDictionary<string, string> parameters)
        {
            using (HttpClient client = CreateClient())
            {
                pageNumber = pageNumber < 1 ? 1 : pageNumber;

                if (!parameters.Keys.Contains("page", StringComparer.OrdinalIgnoreCase))
                    parameters.Add("page", (pageNumber < 1 ? 1 : pageNumber).ToString());

                string cmd = CreateCommand(command, parameters);

                HttpResponseMessage response = await client.GetAsync(cmd).ConfigureAwait(false);

                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    return default(T);

                var result = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return result;
            }
        }

        #endregion

        #region Protected Methods

        protected HttpClient CreateClient()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = false,
                AllowAutoRedirect = false,
                UseDefaultCredentials = true,
                AutomaticDecompression = DecompressionMethods.GZip,
            };

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appliction/json"));
            client.BaseAddress = new Uri(_settings.Url);

            return client;
        }

        protected string CreateCommand(string command, IDictionary<string, string> parameters)
        {
            string commandFull = $"{command}?api_key={_settings.Key}";

            string tokens = parameters.Any()
                ? string.Join("&", parameters.Select(x => x.Key + "=" + x.Value))
                : string.Empty;

            if (string.IsNullOrWhiteSpace(tokens) == false)
                commandFull = $"{commandFull}&{tokens}";

            return commandFull;
        }

        #endregion
    }
}

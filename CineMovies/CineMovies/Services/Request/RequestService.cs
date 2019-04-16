﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CineMovies.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestService()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();

            using (var response = await httpClient.GetAsync(uri))
            { 
                await VerifyResponse(response); 

                string serialized = await response.Content.ReadAsStringAsync();
                TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings)); 
                return result;
            } 
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            return PostAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpClient httpClient = CreateHttpClient();

            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));

            using (var response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json")))
            {
                await VerifyResponse(response);

                string responseData = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
            }
           
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpClient httpClient = CreateHttpClient();
            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));

            using (var response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json")))
            {
                await VerifyResponse(response);

                string responseData = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
            } 
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(AppSettings.ApiUrl);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private async Task VerifyResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized
                    || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception(contentResponse);
                }

                throw new HttpRequestException(contentResponse);
            }
        }
    }
}

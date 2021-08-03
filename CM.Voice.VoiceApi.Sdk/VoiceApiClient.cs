﻿using CM.Voice.VoiceApi.Sdk.Models;
using CM.Voice.VoiceApi.Sdk.Models.Events.Apps;
using CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps;
using System.Text.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Voice.VoiceApi.Sdk
{
    public class VoiceApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Guid _apiKey;
        private readonly string _url;
        private const string ApiKeyHeader = "X-CM-PRODUCTTOKEN";

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="httpClient">The HttpClient to use for sending the instruction. You should use a singleton of this for your entire application.</param>
        /// <param name="apiKey">Your API key or product token, used for authentication.</param>
        /// <param name="url">The base URL of the CM Voice API. Optional.</param>
        public VoiceApiClient(HttpClient httpClient, Guid apiKey, string url = "https://api.cmtelecom.com/voiceapi/v2")
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _url = url;
        }

        /// <summary>
        /// Sends a notification instruction to CM.
        /// </summary>
        /// <param name="instruction">The instruction, containing all information on the call to send out.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        public async Task<VoiceApiResult<CallQueuedEvent>> SendAsync(BaseAppInstruction instruction, CancellationToken cancellationToken = default)
        {
            var urlSuffix = GetUrlSuffix(instruction);

            using (var request = new HttpRequestMessage(HttpMethod.Post, _url + urlSuffix))
            {
                request.Headers.Add(ApiKeyHeader, _apiKey.ToString());
                request.Content = new StringContent(JsonSerializer.Serialize(Convert.ChangeType(instruction, instruction.GetType())), Encoding.UTF8, "application/json");
                using (var result = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var reply = "";
                    if (result.Content != null)
                        reply = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return new VoiceApiResult<CallQueuedEvent>
                    {
                        HttpStatusCode = result.StatusCode,
                        Success = result.IsSuccessStatusCode,
                        Content = reply
                    };
                }
            }
        }

        [Obsolete("See SendAsync")]
        public Task<VoiceApiResult<CallQueuedEvent>> SendInstruction(BaseAppInstruction instruction, CancellationToken cancellationToken = default)
            => SendAsync(instruction, cancellationToken);

        private static string GetUrlSuffix(BaseAppInstruction instruction)
        {
            switch (instruction)
            {
                case NotificationInstruction _:
                    return "/Notification";
                case OtpInstruction _:
                    return "/OTP";
                case RequestDtmfInstruction _:
                    return "/DTMF";
                default:
                    throw new NotImplementedException($"No known endpoint for sending a {instruction.GetType().Name} to the CM VoiceApi.");
            }
        }
    }
}
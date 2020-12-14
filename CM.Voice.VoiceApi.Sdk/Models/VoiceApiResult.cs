using CM.Voice.VoiceApi.Sdk.Models.Events;
using System.Text.Json;
using System.Net;

namespace CM.Voice.VoiceApi.Sdk.Models
{
    public class VoiceApiResult<TEvent> where TEvent : BaseEvent
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public bool Success { get; set; }

        public string Content { get; set; }

        public TEvent DeserializeEvent()
            => JsonSerializer.Deserialize<TEvent>(Content);
    }
}
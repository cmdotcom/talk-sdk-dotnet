using Newtonsoft.Json;
using System;

namespace CM.Voice.VoiceApi.Sdk.Models.Events
{
    public abstract class BaseEvent
    {
        /// <summary>
        /// The Type of event.
        /// </summary>
        [JsonProperty("type", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string Type => this.EventType;

        /// <summary>
        /// The ID of the call this event belongs to.
        /// </summary>
        [JsonProperty("call-id", Order = 2)]
        public Guid CallId { get; set; }


        /// <summary>
        /// The ID of the instruction the event is a result of.
        /// </summary>
        [JsonProperty("instruction-id", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string InstructionId { get; set; }

        /// <summary>
        /// The event type of the event, used for parsing.
        /// </summary>
        protected abstract string EventType { get; }
    }
}

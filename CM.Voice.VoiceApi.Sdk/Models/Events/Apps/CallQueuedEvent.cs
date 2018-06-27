using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CM.Voice.VoiceApi.Sdk.Models.Events
{
    /// <summary>
    /// Event that is a result (basically a direct response) to the PlaceCallInstruction.
    /// This one is generally used in the async versions of the calls.
    /// </summary>
    public class CallQueuedEvent : BaseEvent
    {
        /// <inheritdoc/>
        protected override string EventType => "call-queued";

        /// <summary>
        /// The id (e.g. number) of the caller.
        /// </summary>
        [JsonProperty("caller", Order = 4)]
        public string Caller { get; set; }

        /// <summary>
        /// The id (e.g. number) of the callee.
        /// </summary>
        [JsonProperty("callee", Order = 5)]
        public string Callee { get; set; }

        /// <summary>
        /// True iff the PlaceCallInstruction was accepted.
        /// </summary>
        [JsonProperty("success", Order = 6)]
        public bool Success { get; set; }

        /// <summary>
        /// True iff the PlaceCallInstruction was accepted.
        /// </summary>
        [JsonProperty("error", Order = 6, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}

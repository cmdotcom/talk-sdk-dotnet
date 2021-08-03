using System.Text.Json.Serialization;

namespace CM.Voice.VoiceApi.Sdk.Models.Events.Apps
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
        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        /// <summary>
        /// The id (e.g. number) of the callee.
        /// </summary>
        [JsonPropertyName("callee")]
        public string Callee { get; set; }

        /// <summary>
        /// True iff the PlaceCallInstruction was accepted.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// True iff the PlaceCallInstruction was accepted.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}

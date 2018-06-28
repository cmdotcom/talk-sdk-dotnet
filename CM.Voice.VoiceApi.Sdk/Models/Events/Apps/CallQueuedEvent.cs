using Newtonsoft.Json;
using System;

namespace CM.Voice.VoiceApi.Sdk.Models.Events
{
    /// <summary>
    /// Event that is a result (basically a direct response) to the PlaceCallInstruction.
    /// This one is generally used in the async versions of the calls.
    /// </summary>
    public class CallQueuedEvent : BaseEvent, IEquatable<CallQueuedEvent>
    {
        public bool Equals(CallQueuedEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(Caller, other.Caller) && string.Equals(Callee, other.Callee) && Success == other.Success && string.Equals(Error, other.Error);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CallQueuedEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Caller != null ? Caller.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Callee != null ? Callee.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Success.GetHashCode();
                hashCode = (hashCode * 397) ^ (Error != null ? Error.GetHashCode() : 0);
                return hashCode;
            }
        }

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

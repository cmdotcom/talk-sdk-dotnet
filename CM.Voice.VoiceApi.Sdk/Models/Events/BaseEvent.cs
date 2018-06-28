using Newtonsoft.Json;
using System;

namespace CM.Voice.VoiceApi.Sdk.Models.Events
{
    public abstract class BaseEvent : IEquatable<BaseEvent>
    {
        public bool Equals(BaseEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CallId.Equals(other.CallId) && string.Equals(InstructionId, other.InstructionId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CallId.GetHashCode() * 397) ^ (InstructionId != null ? InstructionId.GetHashCode() : 0);
            }
        }

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

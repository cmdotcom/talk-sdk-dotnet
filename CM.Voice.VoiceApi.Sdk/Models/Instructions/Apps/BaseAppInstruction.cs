using Newtonsoft.Json;
using System;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// Base class for all the initiate outbound call instructions.
    /// </summary>
    public abstract class BaseAppInstruction : IEquatable<BaseAppInstruction>
    {
        public bool Equals(BaseAppInstruction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(InstructionId, other.InstructionId) && string.Equals(Callee, other.Callee) && Equals(Callees, other.Callees) && string.Equals(Caller, other.Caller) && Anonymous == other.Anonymous && DisableCalleesValidation == other.DisableCalleesValidation && string.Equals(CallbackUrl, other.CallbackUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseAppInstruction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (InstructionId != null ? InstructionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Callee != null ? Callee.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Callees != null ? Callees.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Caller != null ? Caller.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Anonymous.GetHashCode();
                hashCode = (hashCode * 397) ^ DisableCalleesValidation.GetHashCode();
                hashCode = (hashCode * 397) ^ (CallbackUrl != null ? CallbackUrl.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        /// The ID of the instruction.
        /// </summary>
        [JsonProperty("instruction-id", Order = 3)]
        public string InstructionId { get; set; }

        /// <summary>
        /// The number to dial.
        /// </summary>
        [JsonProperty("callee", Order = 4)]
        public string Callee { get; set; }

        /// <summary>
        /// The numbers to dial.
        /// </summary>
        [JsonProperty("callees", Order = 4)]
        public string[] Callees { get; set; }


        /// <summary>
        /// The caller id to show on the end user's phone.
        /// </summary>
        [JsonProperty("caller", Order = 5)]
        public string Caller { get; set; }

        /// <summary>
        /// The caller id is hidden iff anonymous = true.
        /// </summary>
        [JsonProperty("anonymous", Order = 6)]
        public bool Anonymous { get; set; }

        /// <summary>
        /// Iff true, the request is not rejected if (any of) the callees are invalid.
        /// Please note that the invalid callees are not dialed, but the valid ones are.
        /// </summary>
        [JsonProperty("disable-callees-validation", Order = 7)]
        public bool DisableCalleesValidation { get; set; }

        /// <summary>
        /// The url to send the POST command to for further VoiceAPI flow.
        /// </summary>
        [JsonProperty("callback-url", Order = 100, NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }
    }
}

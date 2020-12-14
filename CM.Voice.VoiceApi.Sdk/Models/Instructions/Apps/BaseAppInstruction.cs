using System.Text.Json.Serialization;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// Base class for all the initiate outbound call instructions.
    /// </summary>
    public abstract class BaseAppInstruction
    {
        /// <summary>
        /// The ID of the instruction.
        /// </summary>
        [JsonPropertyName("instruction-id")]
        public string InstructionId { get; set; }

        /// <summary>
        /// The number to dial.
        /// </summary>
        [JsonPropertyName("callee")]
        public string Callee { get; set; }

        /// <summary>
        /// The numbers to dial.
        /// </summary>
        [JsonPropertyName("callees")]
        public string[] Callees { get; set; }

        /// <summary>
        /// The caller id to show on the end user's phone.
        /// </summary>
        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        /// <summary>
        /// The caller id is hidden iff anonymous = true.
        /// </summary>
        [JsonPropertyName("anonymous")]
        public bool Anonymous { get; set; }

        /// <summary>
        /// Iff true, the request is not rejected if (any of) the callees are invalid.
        /// Please note that the invalid callees are not dialed, but the valid ones are.
        /// </summary>
        [JsonPropertyName("disable-callees-validation")]
        public bool DisableCalleesValidation { get; set; }

        /// <summary>
        /// Information on the voice to use if (any of) the prompt(s) is of type tts.
        /// </summary>
        [JsonPropertyName("voice")]
        public Voice Voice { get; set; } = new Voice();

        /// <summary>
        /// The url to send the POST command to for further VoiceAPI flow.
        /// </summary>
        [JsonPropertyName("callback-url")]
        public string CallbackUrl { get; set; }
    }
}
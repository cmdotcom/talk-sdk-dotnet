using Newtonsoft.Json;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// This sends the instruction to make and outbound call and send a notification.
    /// </summary>
    public class NotificationInstruction : BaseAppInstruction
    {
        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("prompt", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
        public string Prompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("prompt-type", Order = 8, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? PromptType { get; set; } = Models.PromptType.TTS;

        /// <summary>
        /// Determines the Voicemail detection flow.
        /// </summary>
        [JsonProperty("voicemail-response", Order = 9)]
        public VoicemailResponse VoicemailResponse { get; set; } = VoicemailResponse.Ignore;
    }
}
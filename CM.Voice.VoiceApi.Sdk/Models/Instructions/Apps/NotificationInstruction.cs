using System.Text.Json.Serialization;

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
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("prompt-type")]
        public PromptType? PromptType { get; set; } = Models.PromptType.TTS;

        /// <summary>
        /// Determines the Voicemail detection flow.
        /// </summary>
        [JsonPropertyName("voicemail-response")]
        public VoicemailResponse VoicemailResponse { get; set; } = VoicemailResponse.Ignore;

        /// <summary>
        /// The number of times the code can be played. Min = 1, Max = 3.
        /// </summary>
        [JsonPropertyName("max-replays")]
        public int? MaxReplays { get; set; }

        /// <summary>
        /// The code-prompt and code will replay automatically repeat if true, it will wait for a press on the "1" otherwise.
        /// </summary>
        [JsonPropertyName("auto-replay")]
        public bool? AutoReplay { get; set; }

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("replay-prompt")]
        public string ReplayPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("replay-prompt-type")]
        public PromptType? ReplayPromptType { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// Instruction to send a One Time Password (OTP) to the callee.
    /// </summary>
    public class OtpInstruction : BaseAppInstruction
    {
        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("intro-prompt")]
        public string IntroPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("intro-prompt-type")]
        public PromptType? IntroPromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("code-prompt")]
        public string CodePrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("code-prompt-type")]
        public PromptType? CodePromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The OTP code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("code-type")]
        public CodeType? CodeType { get; set; } = Models.CodeType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("replay-prompt")]
        public string ReplayPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("replay-prompt-type")]
        public PromptType? ReplayPromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("outro-prompt")]
        public string OutroPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("outro-prompt-type")]
        public PromptType? OutroPromptType { get; set; } = PromptType.TTS;

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
        /// Determines the Voicemail detection flow.
        /// </summary>
        [JsonPropertyName("voicemail-response")]
        public VoicemailResponse VoicemailResponse { get; set; } = VoicemailResponse.Ignore;
    }
}
using Newtonsoft.Json;

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
        [JsonProperty("intro-prompt", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
        public string IntroPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("intro-prompt-type", Order = 8, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? IntroPromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("code-prompt", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
        public string CodePrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("code-prompt-type", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? CodePromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The OTP code.
        /// </summary>
        [JsonProperty("code", Order = 11, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("code-type", Order = 12, NullValueHandling = NullValueHandling.Ignore)]
        public CodeType? CodeType { get; set; } = Models.CodeType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("replay-prompt", Order = 13, NullValueHandling = NullValueHandling.Ignore)]
        public string ReplayPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("replay-prompt-type", Order = 14, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? ReplayPromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("outro-prompt", Order = 15, NullValueHandling = NullValueHandling.Ignore)]
        public string OutroPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("outro-prompt-type", Order = 16, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? OutroPromptType { get; set; } = PromptType.TTS;

        /// <summary>
        /// The number of times the code can be played. Min = 1, Max = 3.
        /// </summary>
        [JsonProperty("max-replays", Order = 17, NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxReplays { get; set; }

        /// <summary>
        /// The code-prompt and code will replay automatically repeat if true, it will wait for a press on the "1" otherwise.
        /// </summary>
        [JsonProperty("auto-replay", Order = 18, NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoReplay { get; set; }

        /// <summary>
        /// Determines the Voicemail detection flow.
        /// </summary>
        [JsonProperty("voicemail-response", Order = 19)]
        public VoicemailResponse VoicemailResponse { get; set; } = VoicemailResponse.Ignore;
    }
}
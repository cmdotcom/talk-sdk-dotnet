using System.Text.Json.Serialization;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <inheritdoc />
    /// <summary>
    /// Instruction to place a call and request DTMF from the callee.
    /// </summary>
    public class RequestDtmfInstruction : BaseAppInstruction
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
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("valid-prompt")]
        public string ValidPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("valid-prompt-type")]
        public PromptType? ValidPromptType { get; set; } = Models.PromptType.TTS;

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonPropertyName("invalid-prompt")]
        public string InvalidPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonPropertyName("invalid-prompt-type")]
        public PromptType? InvalidPromptType { get; set; } = Models.PromptType.TTS;

        /// <summary>
        /// The minimum number of digits for the dtmf input
        /// </summary>
        [JsonPropertyName("min-digits")]
        public int? MinDigits { get; set; }

        /// <summary>
        /// The maximum number of digits for the dtmf input
        /// </summary>
        [JsonPropertyName("max-digits")]
        public int? MaxDigits { get; set; }

        /// <summary>
        /// The maximum number of attempts to input valid dtmf.
        /// </summary>
        [JsonPropertyName("max-attempts")]
        public int? MaxAttempts { get; set; }

        /// <summary>
        /// The max timeout for pressing a button.
        /// </summary>
        [JsonPropertyName("timeout")]
        public int? TimeOut { get; set; }

        /// <summary>
        /// The keys that will end dtmf input.
        /// </summary>
        [JsonPropertyName("terminators")]
        public string Terminators { get; set; }

        /// <summary>
        /// The match to use for validating the input.
        /// </summary>
        [JsonPropertyName("regex")]
        public string DigitsRegex { get; set; }
    }
}
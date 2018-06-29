using System;
using Newtonsoft.Json;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// Instruction to send an OTP (One Time Password) to the callee.
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
        public PromptType? IntroPromptType { get; set; }

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("code-prompt", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
        public string CodePrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("code-prompt-type", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? CodePromptType { get; set; }

        /// <summary>
        /// The OTP code.
        /// </summary>
        [JsonProperty("code", Order = 11, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("code-type", Order = 12, NullValueHandling = NullValueHandling.Ignore)]
        public CodeType? CodeType { get; set; }

        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("replay-prompt", Order = 13, NullValueHandling = NullValueHandling.Ignore)]
        public string ReplayPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("replay-prompt-type", Order = 14, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? ReplayPromptType { get; set; }
        /// <summary>
        /// The prompt, which is either the path and name of the file to play, or the string that needs to be tts-ed.
        /// </summary>
        [JsonProperty("outro-prompt", Order = 15, NullValueHandling = NullValueHandling.Ignore)]
        public string OutroPrompt { get; set; }

        /// <summary>
        /// The type of the prompt, either file or tts.
        /// </summary>
        [JsonProperty("outro-prompt-type", Order = 16, NullValueHandling = NullValueHandling.Ignore)]
        public PromptType? OutroPromptType { get; set; }

        /// <summary>
        /// The number of times the code can be played. Min = 1, Max = 10.
        /// </summary>
        [JsonProperty("max-replays", Order = 17, NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxReplays { get; set; }

        /// <summary>
        /// The code-prompt and code will replay automatically repeat if true, it will wait for a press on the "1" otherwise.
        /// </summary>
        [JsonProperty("auto-replay", Order = 17, NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoReplay { get; set; }

        /// <summary>
        /// Information on the voice to use if the prompt is of type tts.
        /// </summary>
        [JsonProperty("voice", Order = 18, NullValueHandling = NullValueHandling.Ignore)]
        public Voice Voice { get; set; }
    }
}

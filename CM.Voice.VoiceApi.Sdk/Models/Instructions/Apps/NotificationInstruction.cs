using Newtonsoft.Json;
using System;

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
        public PromptType? PromptType { get; set; }

        /// <summary>
        /// Information on the voice to use if the prompt is of type tts.
        /// </summary>
        [JsonProperty("voice", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
        public Voice Voice { get; set; }
    }
}

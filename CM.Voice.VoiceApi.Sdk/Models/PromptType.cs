namespace CM.Voice.VoiceApi.Sdk.Models
{
    /// <summary>
    /// The type of the prompt, to distinguish between a filename and a string that needs to be tts-ed.
    /// </summary>
    public enum PromptType
    {
        /// <summary>
        /// Prompt is a filename.
        /// </summary>
        File,
        /// <summary>
        /// Prompt is a TTS string.
        /// </summary>
        TTS
    }
}

namespace CM.Voice.VoiceApi.Sdk.Models
{
    /// <summary>
    /// The type of the code
    /// </summary>
    public enum CodeType
    {
        /// <summary>
        /// Use the default prompts.
        /// </summary>
        Default,
        /// <summary>
        /// Use TTS to spell.
        /// </summary>
        TTS,
        /// <summary>
        /// Use your own custom prompts.
        /// </summary>
        Custom
    }
}
